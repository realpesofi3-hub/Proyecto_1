using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public int reciclados = 0;
    public int insertados = 0;

    public int totalQuemados = 0;

    private bool mensajeInsertarMostrado = false;

    private void Awake()
    {
        instancia = this;
    }

    public void RegistrarQuemados(int cantidad)
    {
        totalQuemados += cantidad;
    }

    public void FusibleReciclado()
    {
        reciclados++;

        VerificarEstado();
    }

    public void FusibleInsertado()
    {
        insertados++;

        VerificarEstado();
    }

    void VerificarEstado()
    {
        // Mostrar mensaje cuando todos los quemados fueron reciclados
        if (reciclados == totalQuemados && !mensajeInsertarMostrado)
        {
            UIManager.instancia.MostrarInsertar();

            mensajeInsertarMostrado = true;
        }

        // Finalizar mantenimiento
        if (totalQuemados > 0 && insertados == totalQuemados)
        {
            UIManager.instancia.MostrarFinal();
        }
    }
}
