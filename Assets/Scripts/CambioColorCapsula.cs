using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
       GetComponent<Renderer>().material.color = new Color(255,0,255,0); 
    }

    private void OnTriggerExit(Collider other)
    {
       GetComponent<Renderer>().material.color = new Color(255, 255, 24, 0);
    }
}
