using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public float speed;
    private float distance;
    private Rigidbody2D r2d;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();    
        player = GameObject.FindGameObjectWithTag("Player");
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Distance", distance);

    }
    private void FixedUpdate()
    {
        if(player != null)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            if (distance > 1.3f)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            }
            if(transform.position.x > player.transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }

}
