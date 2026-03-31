using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    private Transform playerSpawnPoint; // Point de respawn du joueur
    public AudioClip checkpointSound; // Assigner le clip audio de checkpoint dans l'inspecteur

    private void Awake()
    {
        playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(checkpointSound, transform.position); // Joue le son de checkpoint à la position du checkpoint
            playerSpawnPoint.position = transform.position; // Met à jour le point de respawn du joueur
            gameObject.GetComponent<BoxCollider2D>().enabled = false; // Désactive le collider pour éviter de réactiver le checkpoint
        }        
    }
}
