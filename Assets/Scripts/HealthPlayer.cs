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
            TakeDamage(20);
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
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleIncivibilityDelay());
        }
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
