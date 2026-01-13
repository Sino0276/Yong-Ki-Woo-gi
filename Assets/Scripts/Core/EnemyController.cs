using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int id { get; private set; }
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public bool isBoss { get; private set; }
    [field: SerializeField] public bool isDead { get; private set; }

    public event Action<bool> OnDeath;
    public event Action<float> OnHealthChange;

    public void Init(int id, float health, bool isBoss)
    {
        this.id = id;
        Health = isBoss ? health * 10f : health;
        this.isBoss = isBoss;
    }

    public void TakeDamage(float damage)
    {
        if(damage <= 0) return;
        if(isDead) return;

        Health -= damage;
        OnHealthChange?.Invoke(Health);

        if(Health <= 0)
        {
            OnDeath?.Invoke(isBoss);
            isDead = true;
            Destroy(gameObject, Time.deltaTime);
        }
    }
}
