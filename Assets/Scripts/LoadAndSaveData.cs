using UnityEngine;

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

        /*int currentHealth = PlayerPrefs.GetInt("playerHealth", HealthPlayer.instance.maxHealth); // Charger la santé du joueur sauvegardée, maxHealth par défaut
        HealthPlayer.instance.currentHealth = currentHealth;
        HealthPlayer.instance.healthBar.SetHealth(currentHealth); // Mettre à jour la barre de santé avec la santé chargée*/
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
         // Sauvegarder le niveau atteint pour débloquer les niveaux suivants
        if(CurrentSceneManager.instance.levelToUnlock> PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }
        //PlayerPrefs.SetInt("playerHealth", HealthPlayer.instance.currentHealth);
    }


}
