﻿
using UnityEngine;


[CreateAssetMenu(fileName = "new Gun", menuName = "Items/Weapon")]

public class Weapon : Item
{



    public int damageModifier;
    public Vector3 PickUp_Position;
    public Vector3 PickUp_Rotation;
    private Transform _FireWeapon;
    public Transform FireWeapon
    {
        get { return _FireWeapon;}
        set {_FireWeapon = value;}
    }




    public override void Equip()
    {

        base.Equip();


        EquipmentManager.instance.EquipWeapon(this);
        RemoveFromInventory();


    }

    public override void UnEquip()
    {
        base.UnEquip();
        EquipmentManager.instance.UnequipWeapon();

    }
    public override void Use()
    {


        base.Use();
        EquipmentManager.instance.TriggerWeapon();




    }



}
