using UnityEngine;

public class PickupObject : MonoBehaviour
{

    public AudioSource audioSource; // Assigner le son de ramassage dans l'inspecteur
    public AudioClip soundEffect; // Assigner le clip audio de ramassage dans l'inspecteur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(soundEffect, transform.position); // Joue le son de ramassage à la position de l'objet
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
