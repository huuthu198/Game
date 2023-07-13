using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 1.0f;
    public float range = 4f;

    float maceStart;
    int dir = 1;
     
    // Start is called before the first frame update
    void Start()
    {
        maceStart = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up* speed *Time.deltaTime * dir);
        if(transform.position.y < maceStart || transform.position.y > maceStart + range)
        
            dir *= -1;
            
    }
}
