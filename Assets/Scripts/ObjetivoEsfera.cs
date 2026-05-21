using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ObjetivoEsfera : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject textoFinal; 

    [Header("Cambio de color")]
    [Range(0, 255)] public float colorRojo = 255;
    [Range(0, 255)] public float colorVerde = 255;
    [Range(0, 255)] public float colorAzul = 255;

    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(colorRojo / 255f, colorVerde / 255f, colorAzul / 255f, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Activar el texto
        textoFinal.SetActive(true);

        // Opcional: desactivar la esfera
        gameObject.SetActive(false);
    }
}