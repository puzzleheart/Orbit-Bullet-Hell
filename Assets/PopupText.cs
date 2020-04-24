using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    [SerializeField] private string layerToPushTo = "Popup";
    [SerializeField] private float destroyTime = 1f;

    private void Start()
    {
        GetComponent<Renderer>().sortingLayerName = layerToPushTo;
        StartCoroutine(DestroyTextRoutine());
    }

    IEnumerator DestroyTextRoutine()
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(gameObject);
    }
}
