using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingAudio : MonoBehaviour
{
    public AudioSource hitting;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitting.enabled = true;
        }

        /*else
        {
            hitting.enabled = false;
        }*/
    }
}
