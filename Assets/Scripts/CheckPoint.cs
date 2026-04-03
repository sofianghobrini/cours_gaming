using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    public AudioClip checkpointSound; // Assigner le clip audio de checkpoint dans l'inspecteur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(checkpointSound, transform.position); // Joue le son de checkpoint à la position du checkpoint
            CurrentSceneManager.instance.respawnPoint = transform.position; // Met à jour le point de respawn du joueur
            gameObject.GetComponent<BoxCollider2D>().enabled = false; // Désactive le collider pour éviter de réactiver le checkpoint
        }        
    }
}
