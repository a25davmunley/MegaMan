using UnityEngine; // Importa la librería principal de Unity

public class BossShooter : MonoBehaviour // Clase que controla el disparo del boss
{
    public GameObject projectilePrefab; // Prefab del proyectil del boss
    public Transform bossShootPoint; // Punto desde donde dispara el boss

    public Transform player; // Referencia al jugador

    void Shoot() // Método que lanza el proyectil
    {
        GameObject proj = Instantiate(projectilePrefab, bossShootPoint.position, Quaternion.identity); // Crea el proyectil en la posición del boss

        Vector2 dir = (player.position - bossShootPoint.position).normalized; // Calcula la dirección hacia el jugador

        proj.GetComponent<Rigidbody2D>().velocity = dir * 6f; // Aplica velocidad al proyectil hacia el jugador
    }
}