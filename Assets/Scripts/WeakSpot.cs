using UnityEngine;


/*Ce script permet de détruire un objet lorsque le joueur entre en collision avec le point faible*/
public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    public AudioClip killSound; // Assigner le clip audio de kill dans l'inspecteur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position); // Joue le son de kill à la position du point faible
            Destroy(objectToDestroy);
        }
    }
}
