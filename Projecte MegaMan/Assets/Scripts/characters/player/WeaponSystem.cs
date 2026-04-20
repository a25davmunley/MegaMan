using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSystem : MonoBehaviour
{
    public enum WeaponType
    {
        Buster,
        Fire,
        Wind,
        Thunder
    }

    private WeaponType currentWeapon;
    private WeaponType[] weapons;
    private int currentIndex = 0;

    private void Start()
    {
        weapons = new WeaponType[]
        {
            WeaponType.Buster,
            WeaponType.Fire,
            WeaponType.Wind,
            WeaponType.Thunder
        };

        currentWeapon = weapons[currentIndex];
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
            NextWeapon();

        if (Keyboard.current.qKey.wasPressedThisFrame)
            PreviousWeapon();

        if (Keyboard.current.fKey.wasPressedThisFrame)
            Shoot();
    }

    void NextWeapon()
    {
        currentIndex++;

        if (currentIndex >= weapons.Length)
            currentIndex = 0;

        currentWeapon = weapons[currentIndex];
        Debug.Log("Arma: " + currentWeapon);
    }

    void PreviousWeapon()
    {
        currentIndex--;

        if (currentIndex < 0)
            currentIndex = weapons.Length - 1;

        currentWeapon = weapons[currentIndex];
        Debug.Log("Arma: " + currentWeapon);
    }

    void Shoot()
    {
        switch (currentWeapon)
        {
            case WeaponType.Buster:
                Debug.Log("Disparo normal");
                break;

            case WeaponType.Fire:
                Debug.Log("Fuego 🔥");
                break;

            case WeaponType.Wind:
                Debug.Log("Wind");
                break;

            case WeaponType.Thunder:
                Debug.Log("Rayo ⚡");
                break;
        }
    }
}
