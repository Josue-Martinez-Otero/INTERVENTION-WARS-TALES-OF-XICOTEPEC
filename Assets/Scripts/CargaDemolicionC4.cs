using UnityEngine;

public class CargaDemolicionC4 : MonoBehaviour
{
    [Header("Configuración de la C4")]
    public float tiempoExplotacion = 3f; // Segundos antes de detonar
    public float radioExplosion = 5f;    // Área de alcance de la demolición

    // Método para armar y activar la carga en el mapa
    public void ActivarC4()
    {
        Debug.Log("¡Carga C4 colocada en el paso de la sierra! Detonando en " + tiempoExplotacion + " segundos...");
        
        // Llama a la función Detonar después del tiempo configurado
        Invoke("Detonar", tiempoExplotacion);
    }

    void Detonar()
    {
        Debug.Log("¡BOOM! Carga C4 detonada. Ruta bloqueada o enemigos eliminados.");

        // Detecta objetos o enemigos dentro del radio de la explosión
        Collider[] objetosAfectados = Physics.OverlapSphere(transform.position, radioExplosion);

        foreach (Collider obj in objetosAfectados)
        {
            // Si el objeto es un enemigo o un obstáculo del mapa
            if (obj.CompareTag("Enemigo") || obj.CompareTag("ObstaculoDestruible"))
            {
                Destroy(obj.gameObject); // Destruye el objetivo alcanzado por la explosión
            }
        }

        // Destruye el objeto C4 de la escena al terminar la explosión
        Destroy(gameObject);
    }

    // Dibuja una esfera roja en el editor para ver el radio de la explosión
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplosion);
    }
}