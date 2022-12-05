using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class SoldierFlyweightFactory
{
    private static Dictionary<WeaponType, ISoldierFlyweight> Soldiers = new Dictionary<WeaponType, ISoldierFlyweight>();
    public static int SoldierCount { get; private set; }
    
    public static ISoldierFlyweight Soldier (WeaponType weaponType)
    {
        if (!Soldiers.ContainsKey(weaponType))
        {
            switch (weaponType)
            {
                case WeaponType.Sword:
                    Soldiers.Add (weaponType, new Knight());
                    break;
                case WeaponType.Bow:
                    Soldiers.Add (weaponType, new Archer());
                    break;
                case WeaponType.Lance:
                    Soldiers.Add (weaponType, new Calvary());
                    break;
                default:
                    throw new System.Exception("Type of weapon not fit!");
            }

            SoldierCount ++;
        }

        return Soldiers[weaponType];
    }
}
