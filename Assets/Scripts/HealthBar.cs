using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;


    public Gradient gradient;
    public Image fill;

    //Permet de définir la santé maximale et la santé actuelle du joueur dans la barre de vie
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    // Même chose que la fonction précédente mais pour la santé actuelle du joueur
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
