using System.Collections;
using UnityEngine;


public class Weapon : ScriptableObject
{
    public int weaponDamage;
    public float weaponSpeed;
    public float weaponRange;

    [Range(1, 5)] public int weaponLevel;
    public bool isUpgradable;
    public bool isUpgraded;
    public Upgrade upgradeToFuse;
    public Weapon weaponUpgrade;

    public bool canBeUsed;

    public virtual IEnumerator WeaponCooldown()
    {
        canBeUsed = false;
        yield return new WaitForSeconds(1f / weaponSpeed);
        canBeUsed = true;
    }

    public virtual void UseWeapon() { }
    public virtual void UseWeapon(Transform transform) { }
}