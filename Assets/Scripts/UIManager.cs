using TMPro;
using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instancia;

    public GameObject ventana;
    public TextMeshProUGUI texto;

    private void Awake()
    {
        instancia = this;
    }

    private void Start()
    {
        StartCoroutine(MostrarMensajeTemporal(
            "Retire los fusibles quemados y deposítelos en reciclaje",
            5f));
    }

    IEnumerator MostrarMensajeTemporal(string mensaje, float tiempo)
    {
        ventana.SetActive(true);

        texto.text = mensaje;

        yield return new WaitForSeconds(tiempo);

        ventana.SetActive(false);
    }

    public void MostrarInsertar()
    {
        StartCoroutine(MostrarMensajeTemporal(
            "Inserte los fusibles nuevos respetando color y posicion",
            5f));
    }

    public void MostrarFinal()
    {
        ventana.SetActive(true);

        texto.text = "Mantenimiento finalizado";
    }
}
