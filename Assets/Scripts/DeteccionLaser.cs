using System.Collections;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    [Header("Objeto a mover")]
    [SerializeField] private Transform cube;

    [Header("Movimiento")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private Vector3 moveDirection = Vector3.forward;

    [Header("Sensores Laser")]
    [SerializeField] private LaserSensor[] sensors;

    [System.Serializable]
    public class LaserSensor
    {
        public Transform ubicacion;
        [Range(0f, 10f)] public float sensorDistance = 4f;
        public float stopTime = 2f;
        public float continueTime = 2f;
        public Color colorDetected = Color.green;
        public Color colorUndetected = Color.red;
    }

    private bool isStopped = false;

    private void Update()
    {
        MoveCube();

        CheckSensors();
    }

    /// <summary>
    /// Movimiento del cubo
    /// </summary>
    private void MoveCube()
    {
        if (cube == null || isStopped)
            return;

        cube.Translate(moveDirection.normalized * speed * Time.deltaTime);
    }

    /// <summary>
    /// Verifica sensores usando Raycast
    /// </summary>
    private void CheckSensors()
    {
        foreach (LaserSensor sensor in sensors)
        {
            Ray ray = new Ray(sensor.ubicacion.position, sensor.ubicacion.up);

            // Detecta cualquier collider
            if (Physics.Raycast(ray, out RaycastHit hit, sensor.sensorDistance))
            {
                // Color VERDE cuando detecta
                Debug.DrawRay(
                    sensor.ubicacion.position,
                    sensor.ubicacion.up * sensor.sensorDistance,
                    sensor.colorDetected
                );

                // Verifica si detectó el cubo
                if (hit.transform == cube)
                {
                    StartCoroutine(StopCube(sensor.stopTime, sensor.continueTime));
                    return;
                }
            }
            else
            {
                // Color ROJO cuando no detecta
                Debug.DrawRay(
                    sensor.ubicacion.position,
                    sensor.ubicacion.up * sensor.sensorDistance,
                    sensor.colorUndetected
                );
            }
        }
    }

    /// <summary>
    /// Detiene el cubo y luego lo vuelve a mover
    /// </summary>
    private IEnumerator StopCube(float waitTime, float continueTime)
    {

        isStopped = true;

        Debug.Log("Cubo detenido");

        yield return new WaitForSeconds(waitTime);

        isStopped = false;

        Debug.Log("Cubo en movimiento");

        // Pequeña espera para evitar redetección inmediata
        yield return new WaitForSeconds(continueTime);


    }
}