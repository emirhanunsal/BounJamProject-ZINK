using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject bullet;
    [SerializeField] private float speed;
    private float distance;
    [SerializeField] private float shootRate;
    [SerializeField] private Transform firePoint;
    private Rigidbody2D r2d;
   // public Health health;
   // public int currentHP;
    public Animator animator;
    public SpriteRenderer spriteRenderer2;
    void Start()
    {
        spriteRenderer2 = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
       // currentHP = health.currentHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        r2d = GetComponent<Rigidbody2D>();
        StartCoroutine(Shooting());
    }
    private IEnumerator Shooting()
    {
        while (true)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= 3.0f)
                Instantiate(bullet, firePoint.position, quaternion.identity);

            yield return new WaitForSeconds(shootRate);

        }

    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
       // animator.SetFloat("Health", currentHP);
        animator.SetFloat("Distance", distance);

    }
    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance > 3.0f)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (transform.position.x > player.transform.position.x)
        {
            spriteRenderer2.flipX = true;
        }
        else
        {
            spriteRenderer2.flipX = false;
        }

    }
}
