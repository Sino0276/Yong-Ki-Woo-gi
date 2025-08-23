using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [field: SerializeField] public float Health { get; private set; }

    public event Action OnDeath;

    public void Init(float health)
    {
        Health = health;
    }

    public void TakeDamage(float damage)
    {
        if(damage <= 0) return;

        Health -= damage;

        if(Health <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
