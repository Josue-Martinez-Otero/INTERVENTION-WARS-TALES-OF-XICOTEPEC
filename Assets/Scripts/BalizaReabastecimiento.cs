using UnityEngine;

public class BalizaReabastecimiento : MonoBehaviour
{
    [Header("Configuración de la Baliza")]
    public float radioAccion = 5f;          // Área de cobertura de la baliza
    public int puntosDeSuministro = 50;     // Cantidad de curación/munición que otorga

    void Start()
    {
        // Al instanciar la baliza en el mapa, ejecuta el suministro inmediato
        EjecutarReabastecimiento();
    }

    void EjecutarReabastecimiento()
    {
        // Detecta todas las unidades aliadas dentro del radio especificado
        Collider[] unidadesCercanas = Physics.OverlapSphere(transform.position, radioAccion);

        foreach (Collider unidad in unidadesCercanas)
        {
            // Verificamos si la unidad pertenece al bando de la Coalición (etiqueta "Player" o "Infanteria")
            if (unidad.CompareTag("Player") || unidad.CompareTag("InfanteriaAliada"))
            {
                Debug.Log("Suministros aplicados a la unidad: " + unidad.name);
                
                // Aquí puedes conectar con el script de salud/munición de tu compañero cuando lo tenga listo:
                // VidaUnidad vida = unidad.GetComponent<VidaUnidad>();
                // if (vida != null) { vida.Curar(puntosDeSuministro); }
            }
        }
    }

    // Opcional: Dibuja una esfera en editor para ver el radio de la baliza fácilmente
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radioAccion);
    }
}