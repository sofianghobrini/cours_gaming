using UnityEngine;

public class PickupObject : MonoBehaviour
{

    public AudioSource audioSource; // Assigner le son de ramassage dans l'inspecteur
    public AudioClip soundEffect; // Assigner le clip audio de ramassage dans l'inspecteur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(soundEffect); // Joue le son de ramassage
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
