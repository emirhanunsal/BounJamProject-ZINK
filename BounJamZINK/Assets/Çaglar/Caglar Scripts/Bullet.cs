using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] public LayerMask playerMask;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        direction = player.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Pillar"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 30.0f)
        {
            Destroy(gameObject);
        }
        
        Vector2 start = transform.position;
        
        
        // Raycast yap ve sonucu kontrol et
        RaycastHit2D hit = Physics2D.Raycast(start, direction, 1f, playerMask);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                HealthBar.DecreaseHealth();
                Destroy(gameObject);
            }
        }
    }
}
