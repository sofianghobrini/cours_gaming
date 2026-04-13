using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;
    private bool isInRange;
    private Text interactUi;

    private void Awake()
    {
        interactUi = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUi.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUi.enabled = false;
            DialogueManager.instance.EndDialogue();
        }
    }

    private void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
