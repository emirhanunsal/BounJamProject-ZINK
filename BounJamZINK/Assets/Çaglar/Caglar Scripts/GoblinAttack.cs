using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinAttack : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator animator;
    private float attackRate = 0.43f;
    public Health health;
    [SerializeField] private int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private IEnumerator attacking()
    {
        while (true)
        {
            health.TakeDamage(damage);

            yield return attackRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
