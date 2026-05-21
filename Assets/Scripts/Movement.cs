using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float velocidad = 25f;
    // Update is called once per frame
    void Update()
    {
        float moviemientoX = Input.GetAxis("Vertical")*velocidad*Time.deltaTime;
        float rotacionY = Input.GetAxis("Horizontal")*velocidad* Time.deltaTime;
        transform.Translate(new Vector3(moviemientoX,0,0));
        transform.Rotate(new Vector3(0,rotacionY,0));
    }
}
