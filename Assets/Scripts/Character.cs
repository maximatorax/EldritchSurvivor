using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Health;
    public int Strength;
    public float Speed;
    public float AttackSpeed;

    public virtual void Attack()
    {
        
    }

    protected virtual void DoDamage(Collider2D target, int damage)
    {
        target.GetComponent<Character>().TakeDamage(damage);
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}