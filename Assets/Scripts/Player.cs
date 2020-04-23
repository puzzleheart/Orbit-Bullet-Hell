using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private AudioClip hurtSFX = default;
    [SerializeField] private AudioClip deathSFX = default;
    [SerializeField] private float timeInvulnerableOnHit = 1f;
    [SerializeField] GameObject[] orbits = default;

    private bool isInvulnerable = false;
    private Animator anim;

    private void Start()
    {
        orbits[0].SetActive(true);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void TakeDamage(int amount = 1)
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            health--;
            UIManager.Instance.LoseHealthUI();

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

            StartCoroutine(InvulnerableOnHitRoutine());
        }  
    }

    private IEnumerator InvulnerableOnHitRoutine()
    {
        yield return new WaitForSeconds(timeInvulnerableOnHit);
        isInvulnerable = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // There's only one upgrade to orbit available, more than 2 orbits is too strong
    public void UpgradeOrbit()
    {
        if (!orbits[1].activeInHierarchy)
        {
            orbits[1].SetActive(true);
        }
    }
}
