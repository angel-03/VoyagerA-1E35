using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMachine : MonoBehaviour
{
    public GameObject choiceUi;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            choiceUi.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            choiceUi.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } 
    }
}
