using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float  speed = 1.0f;
    int dir = 1;

    public Transform checkRight;
    public Transform checkLeft;
    public LayerMask layer;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * dir * Time.deltaTime);

        if(!Physics2D.Raycast(checkRight.position,Vector3.down, 2,layer) )
            dir = -1;
        if (!Physics2D.Raycast(checkLeft.position, Vector3.down, 2,layer))
            dir = 1;
    }
}
