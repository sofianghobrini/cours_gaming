using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;


    public Animator animator; // Assurez-vous d'avoir un Animator attaché au coffre avec une animation d'ouverture
    public int coinsToAdd;
    public AudioClip chestOpenSound; // Assurez-vous d'avoir un son d'ouverture de coffre dans votre projet
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Ouvrir le coffre
            //Debug.Log("Coffre ouvert !");
            OpenChest();
            interactUI.enabled = false; // Désactive l'UI après l'interaction
        }
    }

    void OpenChest()
    {
        animator.SetTrigger("OpenChest"); // Assurez-vous que votre animation d'ouverture est déclenchée par un trigger nommé "Open"
        Inventory.instance.AddCoins(coinsToAdd); // Ajoutez les pièces au joueur
        AudioManager.instance.PlayClipAt(chestOpenSound, transform.position); // Jouez un son d'ouverture de coffre (assurez-vous d'avoir un son nommé "ChestOpen" dans votre AudioManager)
        GetComponent<BoxCollider2D>().enabled = false; // Désactive le collider pour éviter les interactions répétées
        interactUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
