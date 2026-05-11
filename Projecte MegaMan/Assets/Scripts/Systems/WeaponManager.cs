using UnityEngine; // Importa la librería principal de Unity
using System.Collections.Generic; // Permite usar listas

public class WeaponManager : MonoBehaviour // Clase que gestiona las armas del jugador
{
    public List<WeaponSystem> weapons; // Lista de armas disponibles

    public int currentWeaponIndex = 0; // Índice del arma actual

    public float currentEnergy = 100f; // Energía actual del jugador

    private float lastShootTime; // Último momento en el que se disparó

    void Update() // Se ejecuta cada frame
    {
        // Cambiar arma
        if (Input.GetKeyDown(KeyCode.Tab)) // Si se pulsa TAB
        {
            SwitchWeapon(); // Cambia de arma
        }

        // Disparar
        if (Input.GetKeyDown(KeyCode.Z)) // Si se pulsa Z
        {
            Shoot(); // Dispara el arma actual
        }
    }

    void SwitchWeapon() // Cambia entre armas
    {
        currentWeaponIndex++; // Avanza al siguiente índice

        if (currentWeaponIndex >= weapons.Count) // Si supera la lista
            currentWeaponIndex = 0; // Vuelve al inicio

        Debug.Log("Weapon: " + weapons[currentWeaponIndex].weaponName); // Muestra arma actual
    }

    void Shoot() // Lógica de disparo
    {
        WeaponSystem weapon = weapons[currentWeaponIndex]; // Obtiene arma actual

        if (Time.time < lastShootTime + weapon.cooldown) // Si aún está en cooldown
            return; // No dispara

        if (currentEnergy < weapon.energyCost) // Si no hay energía suficiente
        {
            Debug.Log("Sin energía"); // Mensaje
            return; // Cancela disparo
        }

        Instantiate(weapon.projectilePrefab, transform.position, Quaternion.identity); // Crea proyectil

        currentEnergy -= weapon.energyCost; // Resta energía
        lastShootTime = Time.time; // Actualiza tiempo de disparo
    }
}