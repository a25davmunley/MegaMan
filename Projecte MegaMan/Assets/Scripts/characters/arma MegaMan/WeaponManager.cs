using UnityEngine;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponSystem> weapons;

    public int currentWeaponIndex = 0;

    public float currentEnergy = 100f;

    private float lastShootTime;

    void Update()
    {
        // Cambiar arma
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapon();
        }

        // Disparar
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    void SwitchWeapon()
    {
        currentWeaponIndex++;

        if (currentWeaponIndex >= weapons.Count)
            currentWeaponIndex = 0;

        Debug.Log("Weapon: " + weapons[currentWeaponIndex].weaponName);
    }

    void Shoot()
    {
        WeaponSystem weapon = weapons[currentWeaponIndex];

        if (Time.time < lastShootTime + weapon.cooldown)
            return;

        if (currentEnergy < weapon.energyCost)
        {
            Debug.Log("Sin energía");
            return;
        }

        Instantiate(weapon.projectilePrefab, transform.position, Quaternion.identity);

        currentEnergy -= weapon.energyCost;
        lastShootTime = Time.time;
    }
}