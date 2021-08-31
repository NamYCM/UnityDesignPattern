using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISoldierFlyweight
{
    SoldierStat Stat {get; }
    WeaponType Weapon {get; }

    void LevelUp ();


    UnityEngine.Color GetColor (int hitPoints);
}

public class SoldierStat
{
    public int Attack;
    public int Defense;
    public int MaxHealth;
    public int Dexterity;
    public int Level;
}

public enum WeaponType
{
    Sword, Bow, Lance
}