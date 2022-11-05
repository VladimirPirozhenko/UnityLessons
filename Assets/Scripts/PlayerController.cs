using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] float speed;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        health.OnOutOfHealth += Die;
    }

    private void OnDisable()
    {
        health.OnOutOfHealth -= Die;
    }

    private void Update()
    {
        Move();
        KeepInCameraView();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
   
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void KeepInCameraView()
    {
        Vector3 posInViewport = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        posInViewport.x = Mathf.Clamp01(posInViewport.x);
        posInViewport.y = Mathf.Clamp01(posInViewport.y);
        transform.position = Camera.main.ViewportToWorldPoint(posInViewport);
    }

    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(hor, vert);
        Vector2 velocity = input * speed;
        transform.Translate(velocity * Time.deltaTime);
    }

}
