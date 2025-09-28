using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;

    private Vector2 target;

    public int damage;

    public AudioClip shootSound;
    public AudioClip Die;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Wall"))
        {
            DestroyProjectile();

            Instantiate(player.gameObject.GetComponent<healing>().redEffect, transform.position, transform.rotation);
            player.GetComponent<AudioSource>().PlayOneShot(shootSound);

        }

        if (other.CompareTag("Player"))
        {
            DestroyProjectile();

            other.gameObject.GetComponent<healing>().health -= damage;

        }
        if (player.GetComponent<healing>().health <= 0)
        {
            Instantiate(player.gameObject.GetComponent<healing>().blueEffect, transform.position, transform.rotation);
            player.GetComponent<AudioSource>().PlayOneShot(Die);
        }


    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }



}


