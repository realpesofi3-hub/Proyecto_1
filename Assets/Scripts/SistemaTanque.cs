using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SistemaTanque : MonoBehaviour
{
    [Header("Referencia agua")]
    [SerializeField] private Transform agua;

    [Header("UI")]
    [SerializeField] private TMP_Text textoNivel;

    [Header("Nivel del tanque")]
    [SerializeField] private float nivelActual = 0f;
    [SerializeField] private float nivelObjetivo = 0f;
    [SerializeField] private float velocidadLlenado = 1f;
    [SerializeField] private float nivelMaximo = 10f;

    [Header("Arduino")]
    public ComunicacionArduinoUnity comunicacion;

    private bool motorEncendido = false;
    private bool ledEncendido = false;

    void Start()
    {
        ActualizarAgua();
    }

    void Update()
    {
        bool conectado = comunicacion != null && comunicacion.estadoConexion;

        float tolerancia = 0.05f; //para evitar oscilaciones

        //llenar
        if (nivelActual < nivelObjetivo - tolerancia)
        {
            nivelActual += velocidadLlenado * Time.deltaTime;
            ActualizarAgua();

            if (!motorEncendido && conectado)
            {
                comunicacion.EnviarDato("M1");
                motorEncendido = true;
                ledEncendido = false;
            }
        }

        //vaciar
        else if (nivelActual > nivelObjetivo + tolerancia)
        {
            nivelActual -= velocidadLlenado * Time.deltaTime;
            ActualizarAgua();

            if (!motorEncendido && conectado)
            {
                comunicacion.EnviarDato("M1");
                motorEncendido = true;
                ledEncendido = false;
            }
        }

        //cuando se alcanza el nivel
        else
        {
            nivelActual = nivelObjetivo; //fijar el valor para evitar rebotes 
            ActualizarAgua();

            if (motorEncendido && conectado)
            {
                comunicacion.EnviarDato("M0");
                motorEncendido = false;
            }

            if (!ledEncendido && conectado)
            {
                comunicacion.EnviarDato("L1");
                ledEncendido = true;
            }
        }
    }

    //actualizar el agua y texto
    void ActualizarAgua()
    {
        float alturaMinima = 0.1f;
        float factorEscala = 0.15f;

        float altura = (nivelActual * factorEscala) + alturaMinima;

        agua.localScale = new Vector3(1, altura, 1);

        if (textoNivel != null)
        {
            textoNivel.text = "Nivel: " + nivelActual.ToString("F1") +
                              " / " + nivelMaximo +
                              "\nObjetivo: " + nivelObjetivo;
        }
    }

    //botón de subir
    public void SubirNivel()
    {
        nivelObjetivo += 1f;
        nivelObjetivo = Mathf.Clamp(nivelObjetivo, 0f, nivelMaximo);

        if (comunicacion != null && comunicacion.estadoConexion)
        {
            comunicacion.EnviarDato("L0");
        }

        ledEncendido = false;
    }

    //botón de bajar
    public void BajarNivel()
    {
        nivelObjetivo -= 1f;
        nivelObjetivo = Mathf.Clamp(nivelObjetivo, 0f, nivelMaximo);

        if (comunicacion != null && comunicacion.estadoConexion)
        {
            comunicacion.EnviarDato("L0");
        }

        ledEncendido = false;
    }
}