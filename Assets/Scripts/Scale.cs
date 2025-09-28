using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public SpriteRenderer rink;
    // Start is called before the first frame update
    void Start()
    {
        float orthosize = rink.bounds.size.x * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = orthosize;
    }

    // Update is called once per frame
   
}
