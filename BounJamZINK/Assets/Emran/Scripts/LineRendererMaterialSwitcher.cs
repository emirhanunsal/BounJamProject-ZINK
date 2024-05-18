using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class LineRendererMaterialSwitcher : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Material material0;
    public Material material1;
    public Material material2;
    public float switchInterval = 1.0f;

    private float timer = 0.0f;
    private bool useMaterial1 = true;
    private bool bool1;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
        }
    }

    public void HellYeah()
    {
        while (bool1)
        {
            timer += Time.deltaTime;

                if (timer >= switchInterval)
                {
                    timer = 0.0f;

                    useMaterial1 = !useMaterial1;
                    lineRenderer.material = useMaterial1 ? material1 : material2;
                }

                else
                {
                    lineRenderer.material = material0;
                }
        }
    }
}