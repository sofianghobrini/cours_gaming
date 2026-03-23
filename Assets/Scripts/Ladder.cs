using UnityEngine;          
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{

    private bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider;
    public Text interactUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            //Descendre de l'échelle
            playerMovement.isClimbing = false; // Toggle on/off
            topCollider.isTrigger = false;
            //Debug.Log("Descendre de l'échelle");
            return;
        }
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true; // Toggle on/off
            topCollider.isTrigger = true; // ✅ Désactive le collider pour permettre de traverser l'échelle
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;     
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false; // ✅ Désactive en quittant l'échelle
            topCollider.isTrigger = false; // ✅ Réactive le collider pour empêcher de traverser l
            interactUI.enabled = false;
        }
        
    }
}
