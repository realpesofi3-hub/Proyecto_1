using UnityEngine;

public class Reciclaje : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fusible"))
        {
            GameManager.instancia.FusibleReciclado();

            Destroy(other.gameObject);
        }
    }
}
