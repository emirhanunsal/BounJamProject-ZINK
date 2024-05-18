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
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    private void FixedUpdate()
    {
        if(player != null)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            if (distance > 1.0f)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            }
        }
    }
}
