using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemPriceText;
    public Text itemNameText;
    public Image itemIcon;

    public Items item;


    public void BuyItem()
    {

        Inventory inventory = Inventory.instance;

        //Debug.Log("Buying item: " + item.itemName);
        if(inventory.coinsCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.coinsCount -= item.price;
            inventory.UpdateTextUI();
        }
    }
}
