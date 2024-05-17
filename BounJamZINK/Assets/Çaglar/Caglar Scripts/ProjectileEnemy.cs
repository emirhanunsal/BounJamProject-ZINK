using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileE : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player, bullet;
    [SerializeField] private float speed;
    private float distance;
    [SerializeField] private float shootRate;
    [SerializeField] private Transform firePoint;

    void Start()
    {
        StartCoroutine(Shooting());
    }
    private IEnumerator Shooting()
    {
        while (distance <= 13.0f)
        {
            Instantiate(bullet, firePoint.position, quaternion.identity);
            yield return new WaitForSeconds(shootRate);

        }

    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        
        if(distance > 3.0f)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
        

    }
}
