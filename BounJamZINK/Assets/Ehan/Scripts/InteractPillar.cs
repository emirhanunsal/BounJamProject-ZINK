using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPillar : MonoBehaviour
{
    [SerializeField] private LayerMask pillarLayerMask;
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LineRendererScript lineRendererScript;
    
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
            //Debug.Log("PILLLARRRRRRR");
            Transform pillarTransform = hit.collider.gameObject.transform;
            if (Input.GetKeyDown(KeyCode.E))
            {
                lineRendererScript.AddPointToLine(pillarTransform);
                bool nextStatementBool = lineRendererScript.CheckValidLoop();
                if (!nextStatementBool)
                {
                    lineRendererScript.CheckInvalidCompleteLoop();
                }
            }
        }
        else
        {
            //Debug.Log("Raycast hit nothing.");
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

