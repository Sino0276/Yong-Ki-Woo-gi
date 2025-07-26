using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    private bool isCritical;

    private void OriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    public void Init(float damage, bool isCritical)
    {
        this.damage = damage;
        this.isCritical = isCritical;
    }
}
