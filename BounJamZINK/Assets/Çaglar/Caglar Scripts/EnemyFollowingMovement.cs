using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float speed;
    private float distance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
       if(distance > 0.5f)
       {
           transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

       }
       
    }
}
