using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationVFX : MonoBehaviour
{
    // Called by animation events
    public void DestroyOnEnd()
    {
        Destroy(gameObject);
    }
}
