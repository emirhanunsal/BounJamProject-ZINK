using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI remainingRope;
    [SerializeField] private TextMeshProUGUI scor;
    [SerializeField] private UsedRopeCalculations usedRopeCalculations;
    [SerializeField] private LineRendererScript lineRendererScript;
    void Start()
    {
        remainingRope.text = "Remaining Rope " + usedRopeCalculations.ToString();
        scor.text = "Skor " + lineRendererScript.skor.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        remainingRope.text = "Remaining Rope " + usedRopeCalculations.remainingRope.ToString();
        scor.text = "Skor " + lineRendererScript.skor.ToString();
    }
}
