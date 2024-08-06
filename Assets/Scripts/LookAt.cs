using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    Vector3 stayPut;
    Vector3 currentPos;
    public bool look;
    public bool stay;


    void Awake()
    {
        look = true;
        if(stay)
            stayPut = transform.position;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = transform.position;
        if(look)
            transform.LookAt(target);
        if(stay)
        {
            transform.position = new Vector3(currentPos.x,stayPut.y,currentPos.z);
            transform.rotation = Quaternion.Euler(0,transform.rotation.y,transform.rotation.y);
        }
    }
}
