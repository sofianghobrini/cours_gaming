using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad;
    public void StartGame()
    {
        // Charger la scène de jeu
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        
    }

    public void QuitGame()
    {
        // Quitter l'application
        Application.Quit();
    }
}
