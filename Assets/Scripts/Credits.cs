using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    public void LoadMainMenu()
    {
        // Implémentez la logique pour charger le menu principal
        // Par exemple, vous pouvez utiliser SceneManager.LoadScene("MainMenu");
        //Debug.Log("Chargement du menu principal...");
        SceneManager.LoadScene("MainMenu");
    }

    // Permet de skip les crédits en appuyant sur la touche Echap
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }
}
