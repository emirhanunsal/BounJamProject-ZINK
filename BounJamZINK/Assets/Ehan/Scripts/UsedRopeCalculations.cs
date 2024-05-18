using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedRopeCalculations : MonoBehaviour
{
    [SerializeField] private LineRendererScript lineRendererScript;
    public List<Transform> pointsList;
    private float totalDistance = 0f;
    private void Start()
    {
        pointsList = lineRendererScript.points;
    }

    private void Update()
    {
        if (pointsList.Count == 1 || pointsList.Count == 0)
            totalDistance = 0;
    }

    public void CalculateNewDistance()
    {
        for (int i = 0; i < pointsList.Count-1; i++)
        {
            float squaredDistance = (pointsList[i].position - pointsList[i+1].position).sqrMagnitude;
            Debug.Log("Mesafe" + (int)squaredDistance);
            totalDistance += squaredDistance;
        }
    }
}
