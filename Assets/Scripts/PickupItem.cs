using UnityEngine;
using UnityEngine.UI;
public class PickupItem : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Items item;
    public AudioClip itemPick; // Assurez-vous d'avoir un son d'ouverture de coffre dans votre projet
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
            TakeItem();
            interactUI.enabled = false; // Désactive l'UI après l'interaction
        }
    }

    void TakeItem()
    {
        Inventory.instance.content.Add(item); // Ajoutez l'item au joueur
        Inventory.instance.UpdateInventoryUI(); // Mettez à jour l'UI de l'inventaire
        AudioManager.instance.PlayClipAt(itemPick, transform.position); // Jouez un son d'ouverture de coffre (assurez-vous d'avoir un son nommé "ChestOpen" dans votre AudioManager)
        interactUI.enabled = false;
        Destroy(gameObject); // Détruisez l'objet après l'avoir ramassé
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