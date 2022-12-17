using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]  
public class Enemy : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody2D rb;
    private Health health;
    private Weapon weapon;
    private Explosion explosionOnDeath;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        weapon = GetComponent<Weapon>();
        explosionOnDeath = gameObject.GetComponentInChildren<Explosion>();
    }
    void Start()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    void Update()
    {
        Shoot();
    }

    private void OnEnable()
    {
        health.OnOutOfHealth += Die;
    }

    private void OnDisable()
    {
        health.OnOutOfHealth -= Die;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamageDealer damageDealer))
        {
            damageDealer.DealDamage(health) ;
        }
        if (collider.TryGetComponent(out IDamageable damageable))
        {
            DealDamage(damageable);
            gameObject.SetActive(false);
        }
    }

    public void Shoot()
    {
        weapon.Shoot();
    }

    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }

    public void Die()
    {
        explosionOnDeath.gameObject.SetActive(true);
        explosionOnDeath.transform.SetParent(null);
        explosionOnDeath.PlayExplosionAnimaton();
        gameObject.SetActive(false);
    }
}
