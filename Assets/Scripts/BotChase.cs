using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotChase : MonoBehaviour
{
    public Animator animator;

    bool chase, caught;
    public Transform currentPos;
    public Transform player;
    public float runSpeed;
    float distance;
    public LookAt lookAt;

    void Update()
    {
        if(chase)
            ChasePlayer();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("run",true);
            chase = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("run", false);
            animator.SetBool("caught", false);
            chase = false;
            //currentPos.position = Vector3.MoveTowards(currentPos.position, currentPos.position , speed);
        }
    }
    void ChasePlayer()
    {
        var speed = runSpeed * Time.deltaTime;
        if(!caught)
            currentPos.position = Vector3.MoveTowards(currentPos.position, player.position , speed);
        distance = Vector3.Distance (transform.position, player.position);
        if(distance <= 2f)
        {
            caught = true;
            chase = false;
            animator.SetBool("caught", true);
        }
    }
}
