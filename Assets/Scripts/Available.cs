using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Available : MonoBehaviour
{
    public Image img;
    public float cd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cd = BlastWave.Instance.cooldown;
        if (BlastWave.Instance.cooldown >=0)
        {
            img.color = Color.red;
        }
        else
        {
            img.color = Color.white;
        }
    }
}
