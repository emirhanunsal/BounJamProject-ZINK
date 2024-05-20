using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSounds : MonoBehaviour
{
    private AudioSource audioSource;
    private float timer = 0;
   [SerializeField] private float maxTimer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            audioSource.Play();
            timer = 0;
            maxTimer = UnityEngine.Random.Range(4, 8);
        }
    }
}
