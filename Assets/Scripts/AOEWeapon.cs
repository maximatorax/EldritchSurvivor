using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/AOE")]
public class AOEWeapon : Weapon
{
    public override void UseWeapon(Transform transform)
    {
        Collider2D[] hits = new Collider2D[] { };
        hits = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), weaponRange);
        
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.GetComponent<Character>().TakeDamage(weaponDamage);
            }
        }
    }
}
