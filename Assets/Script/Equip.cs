﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {

    GameObject m_Hand;
    WeaponKeeper weaponSeller;
	// Use this for initialization
	void Start () {
        m_Hand = transform.Find("PlayerHand").gameObject;
        weaponSeller = GameObject.FindGameObjectWithTag("WeaponKeeper").GetComponent<WeaponKeeper>();
        if(weaponSeller == null)
        {
            Debug.Log("There supposed to be a weapon keeper");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EquipWeapon(GameObject tarWeapon)
    {
        Debug.Log("Equipping");
        int weaponTypeNum = tarWeapon.GetComponent<Weapon>().weaponTypeNum;
        GameObject weaponBuy = weaponSeller.SellWeapon(weaponTypeNum);
        weaponBuy.transform.position = m_Hand.transform.position;
        weaponBuy.transform.SetParent(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I touch something");
        if (!other.GetComponent<PickUp>().isCooldown)
        {
            if (other.tag == "WeaponPick")
            {
                Debug.Log("I touch a weapon");
                EquipWeapon(other.gameObject);
            }
        }
    }
}
