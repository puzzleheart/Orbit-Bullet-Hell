using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private int scorePoints = 5;
    [SerializeField] private GameObject destroyVFX = default;
    [SerializeField] private AudioClip destroySFX = default;
    [SerializeField] private Color lostHealthColor = default;

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
        else
        {
            Instantiate(destroyVFX, transform.position, transform.rotation);
            AudioManager.Instance.PlayClip(destroySFX);
            CameraShake.Instance.CamShake();
            GetComponent<SpriteRenderer>().color = lostHealthColor;
        }
    }

    public void Die()
    {
        Instantiate(destroyVFX, transform.position, transform.rotation);
        AudioManager.Instance.PlayClip(destroySFX);
        CameraShake.Instance.CamShake();
        LevelManager.Instance.IncreaseScore(scorePoints);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage();
            Die();
        }
    }
}
