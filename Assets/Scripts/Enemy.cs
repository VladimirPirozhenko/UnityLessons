using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamageable damageable))
        {
            DealDamage(damageable);
            gameObject.SetActive(false);
        }
    }

    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }

}
