using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public static event Action<PlayerStats> OnPlayerDefeat;
    [SerializeField] int health, maxHealth = 100;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void LooseHealth(int damageAmount)
    {
        health -= damageAmount;

        healthBar.SetHealth(health);

        if(health <= 0)
        {
            Destroy(gameObject);
            OnPlayerDefeat?.Invoke(this);
        }
    }
}
