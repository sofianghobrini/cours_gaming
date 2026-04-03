using UnityEngine;
using System.Collections;
public class DeathZone : MonoBehaviour
{


    private Animator fadeSystem; // Référence à l'Animator pour le fade
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn"); // Déclenche l'animation de fade out
        yield return new WaitForSeconds(1f); // Attendre que l'animation de fade out soit terminée
        collision.transform.position = CurrentSceneManager.instance.respawnPoint;
    }
}
