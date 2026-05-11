using UnityEngine; // Importa la librería principal de Unity

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Weapon")] // Permite crear este ScriptableObject desde el menú de Unity
public class WeaponSystem : ScriptableObject // Clase de datos para armas (no es un MonoBehaviour)
{
    public string weaponName; // Nombre del arma

    public GameObject projectilePrefab; // Prefab del proyectil que dispara el arma

    public float damage; // Daño del arma
    public float cooldown; // Tiempo de espera entre disparos
    public float energyCost; // Coste de energía por disparo
}