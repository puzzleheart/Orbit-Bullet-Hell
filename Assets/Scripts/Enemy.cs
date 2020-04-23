using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float moveSpeed = 3f;

    private Transform playerTransform;
    private Rigidbody2D rb;

    private void Start()
    {
        playerTransform = LevelManager.Instance.player.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        //Rotate to look at player
        transform.up = playerTransform.position - transform.position;

        Vector3 moveDirection = playerTransform.position - transform.position;
        moveDirection.Normalize();

        rb.velocity = moveDirection * moveSpeed;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //TODO animations, particles, sound
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage();
        }
    }
}
