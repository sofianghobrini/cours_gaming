using UnityEngine;

public class HealPowerUP : MonoBehaviour
{
    public int healPoints = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HealthPlayer.instance.currentHealth < HealthPlayer.instance.maxHealth)
            {
                //Rendre de la vie au joueur
                HealthPlayer.instance.HealPlayer(healPoints);
                Destroy(gameObject);
            }
        }
    }
}
