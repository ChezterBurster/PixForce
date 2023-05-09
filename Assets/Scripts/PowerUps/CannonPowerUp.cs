using System;
using System.Collections;
using System.Collections.Generic;
using Equipments;
using UnityEngine;

public class CannonPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("player"))
            return;
        var _equipmentManager = col.GetComponent<EquipmentManager>();
        Debug.Log("chupa pito");
        if (_equipmentManager.weapon.bulletAmount < 4)
        {
            Powerup(_equipmentManager.weapon);
            _equipmentManager.RefreshWeapon();
        }
       
    }

    private void Powerup(Weapon weapon)
    {
        Debug.Log("Aumento de balas");
        weapon.bulletAmount ++;
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
