using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ship")
        {
            SceneManager.LoadScene("SampleScene");
            Debug.LogWarning("Ship");
        }
        if(other.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("SampleScene");
            Debug.LogWarning("Player");
        }
    }   
}
