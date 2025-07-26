using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public float Health { get; private set; }

    public void TakeDamage(float damage)
    {
        if(damage <= 0) return;

        Health -= damage;

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
