using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadSpecificScene : MonoBehaviour
{

    public string sceneName; // Le nom de la scène à charger
    public Animator fadeSystem; // Référence à l'Animator pour le fade
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn"); // Déclenche l'animation de fade out
        yield return new WaitForSeconds(1f); // Attendre que l'animation de
        SceneManager.LoadScene(sceneName); // Charger la scène suivante
    }
}
