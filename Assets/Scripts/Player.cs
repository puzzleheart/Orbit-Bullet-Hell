using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private AudioClip hurtSFX = default;
    [SerializeField] private AudioClip deathSFX = default;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void TakeDamage(int amount = 1)
    {
        health--;

        if (health <= 0)
        {
            anim.SetTrigger("deathTrigger");
            CameraShake.Instance.StrongCamShake();
            AudioManager.Instance.PlayClip(deathSFX);
        }
        else
        {
            anim.SetTrigger("hitTrigger");
            AudioManager.Instance.PlayClip(hurtSFX);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
