using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Melee")]
public class MeleeWeapon : Weapon
{
    public float weaponSize;
    public WeaponDirection weaponDirection;

    public override void UseWeapon(Transform transform)
    {
        Collider2D[] hits = new Collider2D[] { };
        switch (weaponDirection)
        {
            case Weapon.WeaponDirection.N:
                hits = Physics2D.OverlapBoxAll(
                    transform.position + new Vector3(0f, weaponRange / 2f, 0f),
                    new Vector2(weaponSize, weaponRange),
                    0, LayerMask.GetMask("Enemy"));
                break;
            case Weapon.WeaponDirection.NE:
                hits = Physics2D.OverlapBoxAll(
                    transform.position + new Vector3(transform.localScale.x, transform.localScale.y, 0f),
                    new Vector2(weaponRange, weaponSize),
                    45, LayerMask.GetMask("Enemy"));
                break;
            case Weapon.WeaponDirection.E:
                hits = Physics2D.OverlapBoxAll(
                    transform.position + new Vector3(weaponRange / 2f, 0f, 0f),
                    new Vector2(weaponRange, weaponSize),
                    0, LayerMask.GetMask("Enemy"));
                break;
            case Weapon.WeaponDirection.SE:
                hits = Physics2D.OverlapBoxAll(
                    transform.position + new Vector3(transform.localScale.x, -transform.localScale.y, 0f),
                    new Vector2(weaponRange, weaponSize),
                    -45, LayerMask.GetMask("Enemy"));
                break;
            case Weapon.WeaponDirection.S:
                hits = Physics2D.OverlapBoxAll(
                    transform.position + new Vector3(0f, -weaponRange / 2f, 0f),
                    new Vector2(weaponSize, weaponRange),
                    0, LayerMask.GetMask("Enemy"));
                break;
            case Weapon.WeaponDirection.SW:
                hits = Physics2D.OverlapBoxAll(
                    transform.position + new Vector3(-transform.localScale.x, -transform.localScale.y, 0f),
                    new Vector2(weaponRange, weaponSize),
                    45, LayerMask.GetMask("Enemy"));
                break;
            case Weapon.WeaponDirection.W:
                hits = Physics2D.OverlapBoxAll(
                    transform.position + new Vector3(-weaponRange / 2f, 0f, 0f),
                    new Vector2(weaponRange, weaponSize),
                    0, LayerMask.GetMask("Enemy"));
                break;
            case Weapon.WeaponDirection.NW:
                hits = Physics2D.OverlapBoxAll(
                    transform.position + new Vector3(-transform.localScale.x, transform.localScale.y, 0f),
                    new Vector2(weaponRange, weaponSize),
                    -45, LayerMask.GetMask("Enemy"));
                break;
        }

        foreach (var hit in hits)
        {
            hit.GetComponent<Character>().TakeDamage(weaponDamage);
        }
    }
}