using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource walking, running, huffing;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walking.enabled = false;
                running.enabled = true;
                huffing.enabled = true;
            }
            else
            {
                walking.enabled = true;
                running.enabled = false;
                huffing.enabled = false;
            }
        }
        else
        {
            walking.enabled = false;
            running.enabled = false;
            huffing.enabled = false;
        }
    }
}


