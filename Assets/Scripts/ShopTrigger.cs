using UnityEngine;
using UnityEngine.UI;
public class ShopTrigger : MonoBehaviour
{

    private bool isInRange;
    private Text interactUi;
    public string pnjName;
    public Items[] itemsToSell;

    private void Awake()
    {
        interactUi = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.instance.OpenShop(itemsToSell, pnjName);
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
            ShopManager.instance.CloseShop();
        }
    }

}
