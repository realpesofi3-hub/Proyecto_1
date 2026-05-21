using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;


public class ComunicacionArduinoUnity : MonoBehaviour
{
    SerialPort arduinoPort;

    [Header("Botones UI")]
    [SerializeField] TMP_Dropdown listaConexiones;
    [SerializeField] Button botonConexion;
    [SerializeField] Button botonDesconexion;
    [SerializeField] Button refrescarPuertos;
    [Header("Objetos Interactivos")]
    [SerializeField] private GameObject cubo;
    [SerializeField] private GameObject prisma; 
    [Header("Puerto serial COM")]
    [SerializeField] private List<string> puertosDisponibles;
    [SerializeField] private int baudRate = 115200;
    public bool estadoConexion = false;

    public void OnTriggerEnter(Collider other)
    {
        arduinoPort.WriteLine("1");
        Debug.Log("Colision detectada, enviando señal al arduino");
    }
    public void OnTriggerExit(Collider other)
    {
        arduinoPort.WriteLine("0");
        Debug.Log("Colision finalizada");
    }

    public void IntentoDeConexion()
    {
        arduinoPort = new SerialPort(listaConexiones.captionText.text, baudRate);
        try
        {
            arduinoPort.Open();
            estadoConexion = true;
            Debug.Log("Puerto serial abierto correctamente");
        }
        catch (Exception e)
        {
            Debug.LogError("Error al abrir el puerto serial: " + e.Message);
        }
    }
    public void Desconectar()
    {
        estadoConexion = false;
        arduinoPort.Close();
        Debug.Log("Puerto serial cerrado correctamente");
    }

    public void RefrescarPuertos()
    {
        puertosDisponibles = new List<string> { };
        foreach (string puerto in SerialPort.GetPortNames())
            puertosDisponibles.Add(puerto);
        listaConexiones.ClearOptions();
        listaConexiones.AddOptions(puertosDisponibles);
    }

    public void EnviarDato(string dato)
    {
        if (estadoConexion)
        {
            arduinoPort.WriteLine(dato);
        }
    }
}
