using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UsedRopeCalculations : MonoBehaviour
{
    [SerializeField] private LineRendererScript lineRendererScript;
    public List<Transform> pointsList;
    public int remainingRope = 1500;
    private void Start()
    {
        pointsList = lineRendererScript.points;
    }

    
    public void CalculateNewDistance()
    {
        if (pointsList.Count >= 2)
        {
            float squaredDistance = (pointsList[pointsList.Count-2].position - pointsList[pointsList.Count-1].position).sqrMagnitude;
            if((remainingRope - (int) (squaredDistance)>0))
            {
                remainingRope = remainingRope - (int)squaredDistance;
            }
            else
            {
                remainingRope = 0;
            }
            

            

            
        }
        
    }
}
