using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambioDeEscenas : MonoBehaviour
{
    public void CambioDeEscena(int numero_escena)
    {
        SceneManager.LoadScene(numero_escena);
    }
}
