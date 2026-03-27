using UnityEngine;
using System.Collections;
public class HealthPlayer : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 2f;
    public float invincibilityDuration = 0.2f;
    public bool isInvincible = false;

    public HealthBar healthBar;
    public SpriteRenderer graphics;
    public static HealthPlayer instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de HealthPlayer dans la scène");
            return;
        }
        instance = this;
    } 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }


    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
       
       healthBar.SetHealth(currentHealth);
    }
    //Pour le test de la barra de vie
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //vérifier si le joueur est vivant ou pas
            if(currentHealth <= 0)
            {
                Die();
                return;
            }
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleIncivibilityDelay());
        }
    }

    public void Die()
    {
        Debug.Log("Le joueur est mort");
        PlayerMovement.instance.enabled = false; // Désactiver le script de mouvement du joueur
        PlayerMovement.instance.animator.SetTrigger("ifDie"); // Déclencher l'animation de mort du joueur
        PlayerMovement.instance.rb.linearVelocity = Vector3.zero; // Arrêter le mouvement du joueur
        PlayerMovement.instance.rb.bodyType=RigidbodyType2D.Kinematic; // passe Dynamic -> Kinematic
        PlayerMovement.instance.playerCollider.enabled = false; // Désactiver le collider du joueur pour éviter les interactions après la mort
        //Ajouter ici les actions à faire quand le joueur meurt (animation, son, etc.)
        GameOverManager.instance.OnPlayerDeath(); // Appeler la méthode pour afficher l'écran de game over
    }

    public void Respawn()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        PlayerMovement.instance.enabled = true; // Réactiver le script de mouvement du joueur
        PlayerMovement.instance.animator.SetTrigger("Respawn"); // Déclencher l'animation de respawn du joueur
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic; // passe Kinematic -> Dynamic
        PlayerMovement.instance.playerCollider.enabled = true; // Réactiver le collider du joueur pour les interactions après le respawn
        //Ajouter ici les actions à faire quand le joueur respawn (animation, son, etc.)
    }
    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f); // Semi-transparent
            yield return new WaitForSeconds(invincibilityDuration);
            graphics.color = new Color(1f, 1f, 1f, 1f); // Fully opaque
            yield return new WaitForSeconds(invincibilityDuration);
        }
    }

    public IEnumerator HandleIncivibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
