using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float damageGiven;



    private void Start()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            Debug.Log(currentHealth);
        }  
        if (Input.GetKeyDown(KeyCode.A))
        {
            Heal(20);
            Debug.Log(currentHealth);
        }  
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Heal(float heal)
    {
        currentHealth += heal;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    
}
