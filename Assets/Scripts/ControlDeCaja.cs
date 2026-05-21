using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlDeCaja : MonoBehaviour
{
    [SerializeField] private Transform cuboObjetivo;
    [SerializeField] Vector3 offset = new Vector3(0, 8f, -10f);
    [Range(0,100)][SerializeField] private float velocidadCamara = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionDeseada = cuboObjetivo.transform.position + offset;
        Vector3 velocidadSuavizado = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara);
        transform.position = velocidadSuavizado;
        transform.LookAt(cuboObjetivo);
    }
}
