using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class SEAScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private InteractPillar interactPillar;
    [SerializeField] private LayerMask seaLayerMask;
    
    // Çarpışma başladığında çalışacak fonksiyon
    private float timer = 0f;
    private float maxTimer = 2f;
    private bool playerInWater = false;

    private void Update()
    {
        Vector2 start = transform.position;

        
        // Raycast'in hedef konumunu hesapla
        
        // Raycast yap ve sonucu kontrol et
        RaycastHit2D hit1 = Physics2D.Raycast(start, interactPillar.lastLookDirection, 5f, seaLayerMask);
        
        if (hit1.collider != null)
        {
            if (hit1.collider.gameObject.CompareTag("SEA"))
            {
                warningText.gameObject.SetActive(true);
            }
            else
            {
                warningText.gameObject.SetActive(false);
            }
        }
        
        RaycastHit2D hit2 = Physics2D.Raycast(start, interactPillar.lastLookDirection, 0.05f, seaLayerMask);
        
        if (hit2.collider != null)
        {
            if (hit2.collider.gameObject.CompareTag("SEA"))
            {
                warningText.gameObject.SetActive(false);
                for (int i = 0; i < 15; i++)
                {
                    HealthBar.DecreaseHealth();
                }
                    
            }
        }

        if (hit1.collider == null)
        {
            warningText.gameObject.SetActive(false);
        }
        
    }

}
