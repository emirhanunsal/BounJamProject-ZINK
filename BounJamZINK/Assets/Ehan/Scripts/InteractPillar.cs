
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPillar : MonoBehaviour
{
    [SerializeField] private LayerMask pillarLayerMask;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LineRendererScript lineRendererScript;
    [SerializeField] private GameObject eButton;
    [SerializeField] private GameObject fButton;
    [SerializeField] private AudioSource tyingSound;
    
    
    public Vector2 lastLookDirection;
    public RaycastHit2D hit;
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 lookDirection = new Vector2(moveX, moveY);
        Vector2 start = transform.position;

        // Sadece bir yön belirtildiğinde raycast yapın
        if (lookDirection != Vector2.zero)
        {
            lastLookDirection = lookDirection;
        }

        // Raycast'in hedef konumunu hesapla
        Vector2 end = start + lastLookDirection * interactDistance;
        
        // Raycast yap ve sonucu kontrol et
        hit = Physics2D.Raycast(start, lastLookDirection, interactDistance, pillarLayerMask);
        
        // Debug çizgisi çiz
        //Debug.DrawRay(start, lastLookDirection * interactDistance, Color.green);
        
        if (hit.collider != null)
        {
            
            Debug.Log(hit.collider.gameObject.transform);
            Transform pillarTransform = hit.collider.gameObject.transform;
            if (lineRendererScript.points.Contains(hit.collider.gameObject.transform))
            {
                Debug.Log("Bu pillar pointste var");
                eButton.SetActive(false);
            }
            else
            {
                eButton.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E) && !lineRendererScript.changeColors)
            {
                lineRendererScript.AddPointToLine(pillarTransform);
                tyingSound.Play();
                bool nextStatementBool = lineRendererScript.CheckValidLoop();
                if (!nextStatementBool)
                {
                    lineRendererScript.CheckInvalidCompleteLoop();
                }
            }
        }
        else if(hit.collider == null)
        {
            eButton.SetActive(false);
        }

        if (hit.collider != null)
        {
            if (lineRendererScript.damageEnabled)
            {
                if(lineRendererScript.points.Contains(hit.collider.gameObject.transform))
                {
                    fButton.SetActive(true);
                }
            }
            else
            {
                fButton.SetActive(false);
            }
        }

        if (hit.collider == null)
        {
            fButton.SetActive(false); 
            eButton.SetActive(false);
        }

        if (lineRendererScript.changeColors)
        {
            fButton.SetActive(false);
        }
        
    }
    
    [SerializeField] private Transform remPillar;
    [SerializeField] private Transform remPillar1;

    public void RemoveColliders()
    {
        //Debug.Log("remove collider calisti");
        lineRendererScript.AddPointToLine(remPillar);
        lineRendererScript.AddPointToLine(remPillar1);
        Invoke("Temp", 0.4f);
    }

    private void Temp()
    {
        lineRendererScript.ClearPointsList(); 
    }

    
}


