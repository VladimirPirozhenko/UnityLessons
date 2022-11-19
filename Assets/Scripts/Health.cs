using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [field: SerializeField] public float maxHP {  get; private set; }
    [field: SerializeField] public float hp { get; private set; }
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
