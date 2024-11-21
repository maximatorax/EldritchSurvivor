using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Range")]
public class RangeWeapon : Weapon
{
    public GameObject projectileToShoot;
    public int numOfProjectiles;
    [Range(0, 360)] public int weaponAngle;
    public int numWavesOfProjectiles;
    public float timeBetweenProjectiles;

    private Transform playerTransform;

    public override void UseWeapon(Transform transform)
    {
        playerTransform = transform;
        for (int i = 0; i < numOfProjectiles; i++)
        {
            var projectile = Instantiate(projectileToShoot, transform.position,
                Quaternion.AngleAxis(weaponAngle * i, new Vector3(0, 0, 1)));
            var projectileComp = projectile.GetComponent<Projectile>();
            projectileComp.Strength = weaponDamage;
            projectileComp.rotation = weaponAngle * i;
        }
    }

    public override IEnumerator WeaponCooldown()
    {
        canBeUsed = false;
        for (int i = 1; i < numWavesOfProjectiles; i++)
        {
            yield return new WaitForSeconds(timeBetweenProjectiles);
            UseWeapon(playerTransform);
        }
        yield return new WaitForSeconds(1f / weaponSpeed);
        canBeUsed = true;
    }
}