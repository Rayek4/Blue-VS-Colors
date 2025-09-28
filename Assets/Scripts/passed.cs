using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passed : MonoBehaviour
{
    public GameObject passedObject;

    public GameObject player;

    public AudioClip Complete;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().PlayOneShot(Complete);
            passedObject.SetActive(true);
            DestroyPlayer();
        }

    }

    void DestroyPlayer()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<force>().enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;
    }
}
