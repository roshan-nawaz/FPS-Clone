using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitch : MonoBehaviour
{
    GunController gunController;
    public int weaponindicator;
    public GameObject[] weapons = new GameObject[3];

    void Start()
    {
        gunController = FindAnyObjectByType<GunController>();
        SelectedWeapon(0);
    }

    public void SelectedWeapon(int index)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);
        weaponindicator = index;
    }

    public void SwitchingWeapon()
    {
            //stopping weapons index from exceeding weapons length
            weaponindicator = (weaponindicator + 1) % weapons.Length;
            SelectedWeapon(weaponindicator);
    }
 
}
