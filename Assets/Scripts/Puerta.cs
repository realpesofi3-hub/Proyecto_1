using UnityEngine;

public class Puerta : MonoBehaviour
{
    private bool abierta = false;

    public Vector3 rotacionAbierta;

    private Vector3 rotacionCerrada;

    private void Start()
    {
        rotacionCerrada = transform.eulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (!abierta)
            {
                transform.eulerAngles = rotacionAbierta;
                abierta = true;
            }
            else
            {
                transform.eulerAngles = rotacionCerrada;
                abierta = false;
            }
        }
    }
}
