using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InsertarFusible : MonoBehaviour
{
    public GameObject fusibleCorrecto;

    private void OnTriggerEnter(Collider other)
    {
        // Si el punto ya tiene un hijo, no insertar
        if (transform.childCount > 0)
            return;

        if (other.gameObject == fusibleCorrecto)
        {
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            // Hacerlo hijo del punto
            other.transform.SetParent(transform);

            Rigidbody rb = other.GetComponent<Rigidbody>();

            rb.isKinematic = true;

            XRGrabInteractable grab =
                other.GetComponent<XRGrabInteractable>();

            grab.enabled = false;
            GameManager.instancia.FusibleInsertado();
        }
    }
}
