using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class Archer : ISoldierFlyweight
{
    private SoldierStat stat = null;

    public SoldierStat Stat
    {
        get 
        {
            if (stat == null)
            {
                stat = new SoldierStat ()
                {
                    Attack = 15,
                    Defense = 4,
                    MaxHealth = 20,
                    Dexterity = 20,
                    Level = 1
                };
            }

            return stat;
        }
    }

    public WeaponType Weapon
    {
        get
        {
            return WeaponType.Bow;
        }
    }

    public void LevelUp ()
    {
        Stat.Level ++;
        Stat.Attack += Stat.Level;
        Stat.Dexterity = (int)Math.Round(1.25f * Stat.Dexterity);
        Stat.MaxHealth += Stat.Level;
        Stat.Defense ++;
    }

    public UnityEngine.Color GetColor (int hitPoints)
    {
        if (hitPoints <= Stat.MaxHealth / 2)
            return Color.red;
        else
            return Color.green;
    }
}

class Knight : ISoldierFlyweight
{
    private SoldierStat stat = null;

    public SoldierStat Stat
    {
        get
        {
            if (stat == null)
            {
                stat = new SoldierStat()
                {
                    Attack = 25,
                    Defense = 20,
                    MaxHealth = 30,
                    Dexterity = 5,
                    Level = 1
                };
            }

            return stat;
        }
    }

    public WeaponType Weapon
    {
        get
        {
            return WeaponType.Sword;
        }
    }

    public void LevelUp()
    {
        Stat.Level++;
        Stat.Attack += (int)Math.Round(1.25f * Stat.Attack);
        Stat.Dexterity += Stat.Level / 2;
        Stat.MaxHealth += Stat.Level;
        Stat.Defense++;
    }

    public Color GetColor(int hitPoints)
    {
        if (hitPoints <= Stat.MaxHealth / 2)
            return Color.magenta;
        else
            return Color.gray;
    }
}


class Calvary : ISoldierFlyweight
{
    private SoldierStat stat = null;

    public SoldierStat Stat
    {
        get
        {
            if (stat == null)
            {
                stat = new SoldierStat()
                {
                    Attack = 30,
                    Defense = 20,
                    MaxHealth = 25,
                    Dexterity = 10,
                    Level = 1
                };
            }

            return stat;
        }
    }

    public WeaponType Weapon
    {
        get
        {
            return WeaponType.Lance;
        }
    }

    public void LevelUp()
    {
        Stat.Level++;
        Stat.Attack += Stat.Level / 2;
        Stat.Dexterity += Stat.Level / 2;
        Stat.MaxHealth += Stat.Level / 2;
        Stat.Defense++;
    }

    public Color GetColor(int hitPoints)
    {
        if (hitPoints <= Stat.MaxHealth / 2)
            return Color.yellow;
        else
            return Color.black;
    }
}
