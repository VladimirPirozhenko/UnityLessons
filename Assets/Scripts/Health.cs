using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHP;
    [SerializeField] float hp;
    public event Action OnOutOfHealth;
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnOutOfHealth?.Invoke();
        }
    }
}
