using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // "Player" etiketi kontrolü
        {
            if (gameObject.CompareTag("HealthPerk"))
            {
                Debug.Log("CAN ARTTI");
                HealthBar.IncreaseHealth();
            }
            else if (gameObject.CompareTag("RopePerk"))
            {
                UsedRopeCalculations.IncreaseRope();
            }
            Destroy(gameObject); // Bonus objesini yok et
        }
    }
}
