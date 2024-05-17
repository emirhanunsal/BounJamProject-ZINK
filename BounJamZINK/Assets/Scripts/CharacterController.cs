using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    public float moveSpeed = 5f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
     void Move()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
    
           
    
            if (moveX == 1)
            {
                sr.flipX = true;
            }
            else if (moveX == -1)
            {
                sr.flipX = false;
            }
            
            
            Vector2 movement = new Vector2(moveX, moveY).normalized;
            rb.velocity = movement * moveSpeed;
    
            if (movement == Vector2.zero)
            {
                rb.velocity = Vector2.zero;
            }
    
            
        }
}
