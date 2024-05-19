using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public static float health = 100f;
    private static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMaxHealth(float _health)
    {
        slider.maxValue = _health;
        slider.value = _health;
    }

    public static void DecreaseHealth()
    {
        health = health - UnityEngine.Random.Range(5, 8);
        audioSource.Play();
    }
    
    public static void IncreaseHealth()
    {
        if ((health + 2 <= 100))
        {
            health = health +2;
        }
        else
        {
            health = 100f;
        }
    }
    
    
    
    

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
    }
}
