using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    public Transform player;
    private Rigidbody2D rb;

    [SerializeField]
    public Transform enemy;

    private float distance;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;

        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
          distance =  Mathf.Sqrt(  Mathf.Pow((player.transform.position.x - transform.position.x),2) +  Mathf.Pow((player.transform.position.y - transform.position.y), 2)  );

  
        if (timeBtwShots<=0)
        {

            if ( distance <= 3 )
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
                
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

         if (distance <= 4)
         {
             Vector3 direction = player.position - transform.position;
             float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             rb.rotation = angle;
         }


    }
}
