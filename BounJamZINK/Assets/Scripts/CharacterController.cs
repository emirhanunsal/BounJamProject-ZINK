using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    
    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Animator bileşenini alın
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        bool isMoving = moveX != 0 || moveY != 0; // Hareket edip etmediğini kontrol edin
        animator.SetBool("isMoving", isMoving); // Animator'daki parametreyi güncelleyin
    
        if (moveX == 1)
        {
            sr.flipX = false;
        }
        else if (moveX == -1)
        {
            sr.flipX = true;
        }
            
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.velocity = movement * moveSpeed;

        if (movement == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
    }
}