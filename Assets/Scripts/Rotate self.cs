using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateself : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.Rotate(xAngle, yAngle, zAngle, Space.Self); 
    }
}
