using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth;
    [SerializeField] HealthBar healthBar;
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        healthBar = FindObjectOfType<HealthBar>();
        InitializeHealthStatus();
    }

    public void InitializeHealthStatus()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame


    public float GetHealth()
    {
        return currentHealth;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }


    public void UpdateHealth(float healthPoints)
    {
        currentHealth = Mathf.Clamp(currentHealth + healthPoints, 0, maxHealth);
        
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            player.Die();
        }
    }
}
