using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public enum UpgradeType
    {
        Health,
        Strength,
        Speed,
        AttackSpeed,
        Money,
        Experience,
        WeaponBoost
    }

    public UpgradeType upgradeType;
    
    [Range(1, 5)] public int upgradeLevel;
    public bool isUpgradable;
}
