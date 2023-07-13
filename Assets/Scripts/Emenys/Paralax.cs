using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBG;
    public Transform sideBG;

    public float length = 23.15f;
    

    // Update is called once per frame
    void Update()
    {
        if (mainCam.position.x > midBG.position.x)
        {
            sideBG.position = midBG.position + Vector3.right * length;
        }    
        if(mainCam.position.x < midBG.position.x)
        {
            sideBG.position = midBG.position + Vector3.left * length;
        }
        if(mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform z = midBG;
            midBG = sideBG;
            sideBG = z;
        }
    }
}
