using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public enum WeaponType
    {
        Melee,
        Range
    }

    public enum WeaponDirection
    {
        N,
        NE,
        E,
        SE,
        S,
        SW,
        W,
        NW
    }

    public int weaponDamage;
    public float weaponSpeed;
    public WeaponType weaponType;
    public float range;
    public float weaponSize;

    public GameObject projectile;
    public int numOfProjectiles;
    public WeaponDirection weaponDirection;
    [Range(0, 360)] public int weaponAngle;

    [Range(1, 5)] public int weaponLevel;
    public bool isUpgradable;
    public bool isUpgraded;
    public Upgrade upgradeToFuse;
    public Weapon weaponUpgrade;

    public bool canBeUsed;

    public IEnumerator WeaponCooldown()
    {
        canBeUsed = false;
        yield return new WaitForSeconds(1f / weaponSpeed);
        canBeUsed = true;
    }
}