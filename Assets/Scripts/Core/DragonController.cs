using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private AttackHandler[] attackHandlers;
    private int currentAttackHandlerIndex = 0;    

    private void Awake()
    {
        attackHandlers = GetComponentsInChildren<AttackHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    public void Attack()
    {
        attackHandlers[currentAttackHandlerIndex].Attack();
        currentAttackHandlerIndex++;
        if (currentAttackHandlerIndex >= attackHandlers.Length)
        {
            currentAttackHandlerIndex = 0;
        }
    }
}
