using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth;
    private float currentHealth;
    public Health health;

    private void Start()
    {
        maxHealth = health.maxHP;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        currentHealth = health.currentHP;
        maxHealth = health.maxHP;
        healthBar.value = currentHealth / maxHealth;
        if (currentHealth < 50)
        {
            healthBar.fillRect.GetComponentInChildren<Image>().color = Color.red;
        }
        
    }
}