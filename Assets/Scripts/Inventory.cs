using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;
public class Inventory : MonoBehaviour
{

    public List<Items> content = new List<Items>();
    public int contentCurrentIndex = 0;
    public Image itemImageUI;
    public Text itemTextUI;
    public Sprite emptyItemImage;
    public int coinsCount;

    public static Inventory instance;
    public Text coinsCountText;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    void Start()
    {
        UpdateInventoryUI();
    }

    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            Debug.Log("L'inventaire est vide");
            return;
        }

        Items currentItem = content[contentCurrentIndex];
        HealthPlayer.instance.HealPlayer(currentItem.bonusHealth);
        PlayerMovement.instance.moveSpeed += currentItem.bonusSpeed;
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {

        if (content.Count == 0)
        {
            Debug.Log("L'inventaire est vide");
            return;
        }

        contentCurrentIndex++;
        if (contentCurrentIndex >= content.Count -1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            Debug.Log("L'inventaire est vide");
            return;
        }

        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }

        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemTextUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemTextUI.text = "";
        }
        
    }
    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}
