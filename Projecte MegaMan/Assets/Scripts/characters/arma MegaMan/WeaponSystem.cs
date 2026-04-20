using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Weapon")]
public class WeaponSystem : ScriptableObject
{
    public string weaponName;

    public GameObject projectilePrefab;

    public float damage;
    public float cooldown;
    public float energyCost;
}
