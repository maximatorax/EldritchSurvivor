using System;
using UnityEngine;

public class Projectile : Character
{ 
    public float rotation;
    
    private void Start()
    {
        if (rotation >= 360)
        {
            rotation %= 360;
        }
    }

    void FixedUpdate()
    {
        switch (rotation)
        {
            case 0 :
                transform.position += Vector3.right * Speed;
                break;
            case 45 :
                transform.position += (Vector3.up + Vector3.right) * Speed;
                break;
            case 90 :
                transform.position += Vector3.up * Speed;
                break;
            case 135 :
                transform.position += (Vector3.up + Vector3.left) * Speed;
                break;
            case 180 :
                transform.position += Vector3.left * Speed;
                break;
            case 225 :
                transform.position += (Vector3.down + Vector3.left) * Speed;
                break;
            case 270 :
                transform.position += Vector3.down * Speed;
                break;
            case 315 :
                transform.position += (Vector3.down + Vector3.right) * Speed;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DoDamage(other.collider, Strength);
            Die();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
