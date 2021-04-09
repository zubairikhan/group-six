using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float GetHealth()
    {
        return currentHealth;
    }

    public void UpdateHealth(float healthPoints)
    {
        currentHealth = Mathf.Clamp(currentHealth + healthPoints, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}
