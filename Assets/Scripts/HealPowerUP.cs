using UnityEngine;

public class HealPowerUP : MonoBehaviour
{
    public int healPoints = 20;
    public AudioClip healSound; // Assigner le clip audio de soin dans l'inspecteur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HealthPlayer.instance.currentHealth < HealthPlayer.instance.maxHealth)
            {
                AudioManager.instance.PlayClipAt(healSound, transform.position); // Joue le son de soin à la position de l'objet
                //Rendre de la vie au joueur
                HealthPlayer.instance.HealPlayer(healPoints);
                Destroy(gameObject);
            }
        }
    }
}
