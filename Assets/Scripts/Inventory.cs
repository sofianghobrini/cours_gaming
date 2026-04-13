using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;
public class Inventory : MonoBehaviour
{

    public List<Items> content = new List<Items>();
    public int contentCurrentIndex = 0;
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

    public void ConsumeItem()
    {
        Items currentItem = content[contentCurrentIndex];
        HealthPlayer.instance.HealPlayer(currentItem.bonusHealth);
        PlayerMovement.instance.moveSpeed += currentItem.bonusSpeed;
        content.Remove(currentItem);
        GetNextItem();
    }

    public void GetNextItem()
    {
        contentCurrentIndex++;
        if (contentCurrentIndex >= content.Count -1)
        {
            contentCurrentIndex = 0;
        }
    }

    public void GetPreviousItem()
    {
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
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
