using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Character
{
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;
    private float speed;
    
    public Weapon[] Weapons = new Weapon[6];
    public Upgrade[] Upgrades = new Upgrade[6];

    private void Awake()
    {
        foreach (var weapon in Weapons)
        {
            if (!weapon) return;
            weapon.canBeUsed = true;
        }
    }

    private void Start()
    {
        speed = GetComponent<Character>().Speed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY);
        rb.AddForce(movement * speed);
    }

    public override void Attack()
    {
        foreach (var weapon in Weapons)
        {
            if (!weapon) return;
            if (weapon.canBeUsed)
            {
                UseWeapon(weapon);
            }
        }
    }
    
    public void UseWeapon(Weapon weapon)
    {
        StartCoroutine(weapon.WeaponCooldown());
        var charTransform = transform;
        switch (weapon.weaponType)
        {
            case Weapon.WeaponType.Melee:
                Collider2D[] hits = new Collider2D[] { };
                switch (weapon.weaponDirection)
                {
                    case Weapon.WeaponDirection.N:
                        hits = Physics2D.OverlapBoxAll(
                            charTransform.position + new Vector3(0f, weapon.range / 2f, 0f),
                            new Vector2(weapon.weaponSize, weapon.range),
                            0, LayerMask.GetMask("Enemy"));
                        break;
                    case Weapon.WeaponDirection.NE:
                        hits = Physics2D.OverlapBoxAll(
                            charTransform.position + new Vector3(charTransform.localScale.x, charTransform.localScale.y, 0f),
                            new Vector2(weapon.range, weapon.weaponSize),
                            45, LayerMask.GetMask("Enemy"));
                        break;
                    case Weapon.WeaponDirection.E:
                        hits = Physics2D.OverlapBoxAll(
                            charTransform.position + new Vector3(weapon.range / 2f, 0f, 0f),
                            new Vector2(weapon.range, weapon.weaponSize),
                            0, LayerMask.GetMask("Enemy"));
                        break;
                    case Weapon.WeaponDirection.SE:
                        hits = Physics2D.OverlapBoxAll(
                            charTransform.position + new Vector3(charTransform.localScale.x, -charTransform.localScale.y, 0f),
                            new Vector2(weapon.range, weapon.weaponSize),
                            -45, LayerMask.GetMask("Enemy"));
                        break;
                    case Weapon.WeaponDirection.S:
                        hits = Physics2D.OverlapBoxAll(
                            charTransform.position + new Vector3(0f, -weapon.range / 2f, 0f),
                            new Vector2(weapon.weaponSize, weapon.range),
                            0, LayerMask.GetMask("Enemy"));
                        break;
                    case Weapon.WeaponDirection.SW:
                        hits = Physics2D.OverlapBoxAll(
                            charTransform.position + new Vector3(-charTransform.localScale.x, -charTransform.localScale.y, 0f),
                            new Vector2(weapon.range, weapon.weaponSize),
                            45, LayerMask.GetMask("Enemy"));
                        break;
                    case Weapon.WeaponDirection.W:
                        hits = Physics2D.OverlapBoxAll(
                            charTransform.position + new Vector3(-weapon.range / 2f, 0f, 0f),
                            new Vector2(weapon.range, weapon.weaponSize),
                            0, LayerMask.GetMask("Enemy"));
                        break;
                    case Weapon.WeaponDirection.NW:
                        hits = Physics2D.OverlapBoxAll(
                            charTransform.position + new Vector3(-charTransform.localScale.x, charTransform.localScale.y, 0f),
                            new Vector2(weapon.range, weapon.weaponSize),
                            -45, LayerMask.GetMask("Enemy"));
                        break;
                }

                foreach (var hit in hits)
                {
                    DoDamage(hit, weapon.weaponDamage);
                }

                break;
            case Weapon.WeaponType.Range:
                for (int i = 0; i < weapon.numOfProjectiles; i++)
                {
                    var projectile = Instantiate(weapon.projectile, charTransform.position,
                        Quaternion.AngleAxis(weapon.weaponAngle * i, new Vector3(0, 0, 1)));
                    var projComponent = projectile.GetComponent<Projectile>();
                    projComponent.Strength = weapon.weaponDamage;
                    projComponent.rotation = weapon.weaponAngle * i;
                }
                break;
        }
    }
}
