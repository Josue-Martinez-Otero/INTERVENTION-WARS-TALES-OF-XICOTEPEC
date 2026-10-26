using UnityEngine;

public class DronMapeoTactivo : MonoBehaviour
{
    [Header("Configuración de Mapeo")]
    public float radioDespeje = 15f;    // Área amplia que cubre el dron desde el aire
    public float duracionVuelo = 10f;   // Tiempo que el dron permanece activo disipando la niebla

    void Start()
    {
        // Activa la función de escaneo aéreo al desplegarse
        DesplegarMapeoAereo();

        // El dron cumple su misión y desaparece de la escena después del tiempo establecido
        Destroy(gameObject, duracionVuelo);
    }

    void DesplegarMapeoAereo()
    {
        Debug.Log("¡Dron de Mapeo Táctico desplegado! Disipando niebla de guerra en el sector.");

        // Detecta unidades o elementos ocultos en el área de la sierra
        Collider[] elementosEnZona = Physics.OverlapSphere(transform.position, radioDespeje);

        foreach (Collider elemento in elementosEnZona)
        {
            // Aquí puedes conectar con el sistema de "Niebla de Guerra" (Fog of War) de tu juego
            if (elemento.CompareTag("EnemigoOculto") || elemento.CompareTag("EstructuraEnemiga"))
            {
                Debug.Log("¡Enemigo detectado por el dron en las alturas: " + elemento.name + "!");
                
                // Ejemplo para revelar al enemigo:
                // elemento.gameObject.SetActive(true);
            }
        }
    }

    // Dibuja una esfera amarilla en el editor para visualizar el cono/radio de escaneo aéreo
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDespeje);
    }
}