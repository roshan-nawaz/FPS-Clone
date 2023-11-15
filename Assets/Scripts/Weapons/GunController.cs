using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    private WeaponSwitch weaponSwitch;

    [SerializeField]
    private bool rapidFire = false;
    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float firerate = 30f;
    [SerializeField]
    private ParticleSystem muzzleFlash;
    [SerializeField]
    private GameObject impactEffect;
    [SerializeField]
    private int maxAmmo = 30;
    [SerializeField]
    private int currentAmmo;
    [SerializeField]
    private float reloadTime = 3f;

    WaitForSeconds rapidFireRateWait;
    WaitForSeconds reloadWait;

    Coroutine FireCoroutine;
    private InputManager inputManager;
    private bool isReloading = false;
    [SerializeField]
    private bool isShooting = false;

    private void Awake()
    {
        weaponSwitch = GetComponent<WeaponSwitch>();
        inputManager = FindObjectOfType<InputManager>();
        currentAmmo = maxAmmo;

    }

    public void StartFiring()
    {
        isShooting = true;
        Shoot();
        if (rapidFire == true)
        {
            //repeating shoot
            InvokeRepeating("Shoot", 1 / firerate, 1 / firerate);
        }
    }


    public void StopFirirng()
    {
        isShooting = false;
        CancelInvoke("Shoot");
    }


    //shooting code 
    public void Shoot()
    {
        if (HasAmmo())
        {
            muzzleFlash.Play();
            currentAmmo--;
            Ray ray = new(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                //Debug.Log(hit.transform.name);

                Enemy enemy = hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
                float force = 80f;
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * force);
                }
                GameObject impactObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        else
        {
            Reload();
        }

    }

    public void Reload()
    {
        if (isReloading == false && currentAmmo < maxAmmo)
        {
            isReloading = true;
            Debug.Log("Reloading...");

            // Simulate reload time with Invoke
            Invoke(nameof(FinishReload), reloadTime);
        }
    }

    private void FinishReload()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reload Complete");
    }


    private bool HasAmmo()
    {
        bool enoughAmmo = currentAmmo > 0;              //true if currentAmmo is greater than 0, false otherwise 
        return enoughAmmo;
    }
}
//all lines below can be replaced by the above line

/*
bool enoughAmmo = false;
if(currentAmmo > 0)
{
    enoughAmmo = true;
}
else
{
    enoughAmmo = false;
}
    return enoughAmmo; 
}
*/