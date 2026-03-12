using UnityEngine;


/*Ce script permet de détruire un objet lorsque le joueur entre en collision avec le point faible*/
public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(objectToDestroy);
        }
    }
}
