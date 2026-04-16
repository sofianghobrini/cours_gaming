using System;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public Text pnjNameText;

    public GameObject sellButtonPrefab;
    public Transform sellButtonsParent;
    public Animator animator;
    public static ShopManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }
        instance = this;
    }

    public void OpenShop(Items[] items, string pnjName)
    {
        pnjNameText.text = pnjName;
        UpdateItemsToSell(items);
        animator.SetBool("isOpen", true);
    }

    void UpdateItemsToSell(Items[] items)
    {
        // On détruit les anciens boutons de vente
        for(int i=0; i<sellButtonsParent.childCount; i++)
        {
            Destroy(sellButtonsParent.GetChild(i).gameObject);
        }
        // On instancie les nouveaux boutons de vente
        for(int i=0; i<items.Length; i++)
        {
            //Debug.Log("Updating shop with " + items[i] + " items.");
            GameObject button = Instantiate(sellButtonPrefab, sellButtonsParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.itemNameText.text = items[i].itemName;
            buttonScript.itemIcon.sprite = items[i].image;
            buttonScript.itemPriceText.text = items[i].price.ToString();

            buttonScript.item = items[i];

            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.BuyItem(); });
        }
    }

    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
    }
}
