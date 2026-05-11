using UnityEngine; // Importa la librería principal de Unity

public class GhostBlock : MonoBehaviour // Bloque que aparece y desaparece periódicamente
{
    public float activeTime = 2f; // Tiempo que el bloque está activo (visible y sólido)
    public float inactiveTime = 2f; // Tiempo que el bloque está inactivo
    public float startDelay = 0f; // Retardo inicial antes de empezar el ciclo

    private SpriteRenderer sr; // Controla la visibilidad del bloque
    private Collider2D col; // Controla la colisión del bloque

    private bool active; // Estado actual (activo o no)
    private float timer; // Temporizador general

    void Start() // Se ejecuta al iniciar el objeto
    {
        sr = GetComponent<SpriteRenderer>(); // Obtiene el SpriteRenderer
        col = GetComponent<Collider2D>(); // Obtiene el Collider2D

        SetState(false); // Empieza apagado (invisible e intangible)
    }

    void Update() // Se ejecuta cada frame
    {
        timer += Time.deltaTime; // Suma el tiempo transcurrido

        if (timer < startDelay) return; // Espera inicial antes de activar el ciclo

        if (active && timer >= startDelay + activeTime) // Si está activo y se cumple el tiempo
        {
            SetState(false); // Se desactiva
            timer = startDelay; // Reinicia el ciclo
        }
        else if (!active && timer >= startDelay + inactiveTime) // Si está inactivo y se cumple el tiempo
        {
            SetState(true); // Se activa
            timer = startDelay; // Reinicia el ciclo
        }
    }

    public void SetState(bool state) // Cambia el estado del bloque
    {
        active = state; // Guarda estado

        sr.enabled = state; // Activa/desactiva visibilidad
        col.enabled = state; // Activa/desactiva colisión
    }
}