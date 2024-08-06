using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyAnomaly : MonoBehaviour
{
    public Animator animator;
    public bool isLaughing;

    void Awake()
    {
        StartLaughing(false);    
    }

    public void StartLaughing(bool isLaughing)
    {
        if(!isLaughing)
        {
            animator.SetBool("laugh",false);
        }
        else
        {
            animator.SetBool("laugh",true);
        }
    }
}
