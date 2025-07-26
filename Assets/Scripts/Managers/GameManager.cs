using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager
{
    [field: SerializeField] public Projectile projectilePrefab { get; private set; }

    public void Init()
    {

    }
}
