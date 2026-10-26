using UnityEngine;

public class EstacionReparacionPortatil : MonoBehaviour
{
    [Header("Configuración de Reparación")]
    public float radioReparacion = 6f;      // Área de cobertura para tanques y mechas
    public float puntosDeReparacion = 10f;  // Cantidad de salud que repara por segundo
    public float duracionEstacion = 15f;    // Tiempo antes de que la estación caduque

    void Start()
    {
        // La estación se autodestruye después de un tiempo determinado en el campo de batalla
        Destroy(gameObject, duracionEstacion);
    }

    void Update()
    {
        // Función continua que busca vehículos y mechas aliados cercanos
        RepararVehiculosCercanos();
    }

    void RepararVehiculosCercanos()
    {
        Collider[] objetosCercanos = Physics.OverlapSphere(transform.position, radioReparacion);

        foreach (Collider obj in objetosCercanos)
        {
            // Verificamos si el objeto es un vehículo o mecha aliado
            if (obj.CompareTag("VehiculoAliado") || obj.CompareTag("Mecha"))
            {
                Debug.Log("Reparando blindaje de: " + obj.name);
                
                // Aquí conectarás con el script de vida del vehículo de tu compañero:
                // VidaVehiculo vidaV = obj.GetComponent<VidaVehiculo>();
                // if (vidaV != null) { vidaV.Reparar(puntosDeReparacion * Time.deltaTime); }
            }
        }
    }

    // Dibuja una esfera azul en el editor para ver el radio de la estación de reparación
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radioReparacion);
    }
}