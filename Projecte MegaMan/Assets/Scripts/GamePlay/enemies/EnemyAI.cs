using UnityEngine;

public class EnemyAI : EnemyBase
// Controla comportamiento general de detección.
{
    public float detectRange = 5f;
    // Distancia a la que detecta al jugador.

    protected bool chasing;
    // Si está persiguiendo al jugador.

    protected virtual void Update()
    {
        if (!player) return;
        // Si no hay jugador, no hace nada.

        float dist = Vector2.Distance(transform.position, player.position);
        // Calcula distancia al jugador.

        chasing = dist <= detectRange;
        // Activa persecución si está cerca.
    }
}