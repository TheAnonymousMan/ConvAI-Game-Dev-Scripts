using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weaponManager;

    public float fireRate = 15f;

    private float nextTimeToFire;

    public float damage = 20f;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    }

    void WeaponShoot()
    {
        if (weaponManager.GetCurrentSelectedWeapon().fireType == WeaponFireType.FULL_AUTO)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();

                //Bullet Fired
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weaponManager.GetCurrentSelectedWeapon().tag.Equals(Tags.AXE_TAG))
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                }
                if(weaponManager.GetCurrentSelectedWeapon().ammoType == WeaponAmmoType.BULLET)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();

                    //Bullet Fired
                }
                else
                {

                }
            }
        }
    }
}
