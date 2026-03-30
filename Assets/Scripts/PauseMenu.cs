using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false; // Désactive le script de mouvement du joueur
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Arrete le temps dans le jeu
        gameIsPaused = true; // change l'état de pause
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reprend le temps dans le jeu
        gameIsPaused = false; // change l'état de pause
    }

    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad(); // Empêche la destruction de l'objet lors du chargement de la nouvelle scèn
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
