using System;
using UnityEngine;

public class LineRendererMaterialSwitcher : MonoBehaviour
{
    public LineRenderer lineRenderer; // LineRenderer bileşenine referans
    public Material material0; // Varsayılan materyal
    public Material material1; // İlk materyal
    public Material material2; // İkinci materyal
    public float switchInterval = 1.0f; // Materyalin ne kadar sıklıkla değiştirileceği (saniye)
    
    private float timer = 0.0f; // Zamanlayıcı
    private bool useMaterial1 = true; // Hangi materyalin kullanılacağını takip eden bool değişken


    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            HellYeah();

        }
        else
        {
            
            lineRenderer.material = material0;
            
        }
    }

    public void HellYeah()
    {
        
            timer += Time.deltaTime;

            if (timer >= switchInterval)
            {
                timer = 0.0f;

                useMaterial1 = !useMaterial1;
                lineRenderer.material = useMaterial1 ? material1 : material2;
            }

        
    }
}

