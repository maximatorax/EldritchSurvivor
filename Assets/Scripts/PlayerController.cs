using System;
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
        base.Attack();
        foreach (var weapon in Weapons)
        {
            if (!weapon) return;
            if (weapon.canBeUsed)
            {
                weapon.UseWeapon(transform);
                StartCoroutine(weapon.WeaponCooldown());
            }
        }
    }
}