using UnityEngine;
using System.Collections.Generic;

public class FusiblesQuemados : MonoBehaviour
{
    public GameObject[] fusibles;
    public Material materialQuemado;

    void Start()
    {
        int cantidadQuemados = Random.Range(1, fusibles.Length + 1);

        GameManager.instancia.RegistrarQuemados(cantidadQuemados);

        List<int> usados = new List<int>();

        for (int i = 0; i < cantidadQuemados; i++)
        {
            int aleatorio;

            do
            {
                aleatorio = Random.Range(0, fusibles.Length);
            }
            while (usados.Contains(aleatorio));

            usados.Add(aleatorio);

            Renderer render = fusibles[aleatorio].GetComponent<Renderer>();

            render.material = materialQuemado;
        }
    }
}
