using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class Powerup : MonoBehaviour
{
    [SerializeField] private GameObject popupText = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(popupText, collision.gameObject.transform.position + Vector3.up, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
