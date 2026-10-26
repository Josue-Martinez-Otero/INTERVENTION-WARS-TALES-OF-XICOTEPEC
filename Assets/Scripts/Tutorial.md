# Intervention Wars: Tales of Xicotepec — Documentación de Ítems

Este documento detalla los ítems tácticos de RTS implementados para el proyecto, su funcionamiento en el juego y el flujo de trabajo para integrarlos mediante Prefabs.

---

## 🛠️ Catálogo de Ítems Creados

### 1. Baliza de Reabastecimiento Táctico
* **Personaje asignado:** Mateo "Gris" Mendoza (Comandante de Campo)
* **Script:** `BalizaReabastecimiento.cs`
* **Descripción:** Es una estructura táctica desplegable desde el aire.
* **Uso en el juego:** Otorga soporte curativo y suministro de munición en un radio definido a todas las unidades de infantería de La Coalición que se encuentren dentro de su zona de alcance al momento de ser activada.

---

### 2. Cargas de Demolición C4
* **Personaje asignado:** Mateo "Gris" Mendoza (Comandante de Campo)
* **Script:** `CargaDemolicionC4.cs`
* **Descripción:** Explosivo táctico de alto impacto con temporizador.
* **Uso en el juego:** Permite dinamitar pasos de montaña estrechos, puentes y bloqueos en los cañones de la Sierra Norte para impedir el paso de las tropas invasoras de Los Ascendidos o destruir escuadrones enemigos atrapados en el área de detonación.

---

### 3. Estación de Reparación Portátil
* **Personaje asignado:** Valeria "Cerbero" Rivas (Ingeniera de Combate)
* **Script:** `EstacionReparacionPortatil.cs`
* **Descripción:** Puesto mecánico temporal de mantenimiento rápido.
* **Uso en el juego:** Se coloca en el campo de batalla para sanar y restaurar de forma continua el blindaje de vehículos y unidades mecha aliadas dentro de su área de cobertura durante un tiempo determinado antes de caducar.

---

### 4. Dron de Mapeo Táctico
* **Personaje asignado:** Diego "Galeón" Cruz (Piloto de Reconocimiento)
* **Script:** `DronMapeoTactivo.cs`
* **Descripción:** Dispositivo volador no tripulado de escaneo topográfico.
* **Uso en el juego:** Se eleva sobre el área de operaciones para disipar la niebla de guerra (*Fog of War*) de un sector amplio en mapas montañosos y boscosos, revelando emboscadas o patrullas enemigas ocultas.

---

## 📦 Instrucciones para la Carpeta `Prefabs` (Punto 3)

Para que los scripts funcionen correctamente y el responsable de la lógica de personajes pueda utilizarlos dentro de Unity, sigue estos pasos:

1. **Creación de la carpeta:** En la ventana **Project** (sección inferior de Unity), asegúrate de tener una carpeta llamada `Prefabs` (dentro de `Assets/`).
2. **Generación del Prefab:** Arrastra cada objeto configurado (`BalizaReabastecimiento`, `CargaC4`, `EstacionReparacion`, `DronMapeoTactic`) desde la **Hierarchy** hacia la carpeta `Prefabs`.
3. **Punto 3 — Uso e Integración del Prefab en Código:** 
   * Una vez que el objeto esté en la carpeta `Prefabs`, el desarrollador a cargo de los personajes puede instanciar cualquiera de estos ítems en tiempo de ejecución desde los scripts de los héroes usando la función:
     ```csharp
     Instantiate(prefabDelItem, posicionDeDespliegue, Quaternion.identity);
     ```
   * Esto permite desplegar los ítems en cualquier punto del mapa cuando el jugador presione el botón o habilidad correspondiente en la interfaz RTS.