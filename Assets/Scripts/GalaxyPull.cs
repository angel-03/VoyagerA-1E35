using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyPull : MonoBehaviour
{
    public GameObject ship;
    public GameObject galaxyPosition;
    public float gravityPull;

    public void GalaxyGravity()
    {
        var gravity = gravityPull * Time.deltaTime;
        //ship.transform.Translate(galaxyPosition.transform.position * gravityPull * Time.deltaTime);
        ship.transform.position = Vector3.MoveTowards(ship.transform.position, galaxyPosition.transform.position, gravity);
    }

    private void Update()
    {
        GalaxyGravity();
    }
}
