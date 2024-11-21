using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Range")]
public class RangeWeapon : Weapon
{
    public GameObject projectileToShoot;
    public int numOfProjectiles;
    [Range(0, 360)] public int weaponAngle;

    public override void UseWeapon(Transform transform)
    {
        base.UseWeapon();

        for (int i = 0; i < numOfProjectiles; i++)
        {
            var projectile = Instantiate(projectileToShoot, transform.position,
                Quaternion.AngleAxis(weaponAngle * i, new Vector3(0, 0, 1)));
            var projectileComp = projectile.GetComponent<Projectile>();
            projectileComp.Strength = weaponDamage;
            projectileComp.rotation = weaponAngle * i;
        }
    }
}