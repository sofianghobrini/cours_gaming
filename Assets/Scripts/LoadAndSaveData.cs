using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    
    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }
        instance = this;
    } 

    void Start()
    {
       Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0); // Charger le nombre de pièces sauvegardé, 0 par défaut 
       Inventory.instance.UpdateTextUI(); // Mettre à jour l'affichage du nombre de pièces

    
       string[] itemsSaved = PlayerPrefs.GetString("inventoryItems","").Split(',');
        for (int i = 0; i < itemsSaved.Length; i++)
        {
            Debug.Log("Item " + i + ": " + itemsSaved[i]);
            if(itemsSaved[i] != "")
            {
                //Ajout d'item
                int id = int.Parse(itemsSaved[i]);
                Items currentItem = ItemsDataBase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }
        }
        Inventory.instance.UpdateInventoryUI(); // Mettre à jour l'affichage de l'inventaire
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
         // Sauvegarder le niveau atteint pour débloquer les niveaux suivants
        if(CurrentSceneManager.instance.levelToUnlock> PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }
        
        // save

        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", itemsInInventory);
        //Debug.Log("Saving items in inventory: " + itemsInInventory);
        

    }


}
