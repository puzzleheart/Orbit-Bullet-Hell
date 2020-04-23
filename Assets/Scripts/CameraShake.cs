using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : Singleton<CameraShake>
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void CamShake()
    {
        anim.SetTrigger("shakeTrigger");
    }

    public void StrongCamShake()
    {
        anim.SetTrigger("strongShakeTrigger");
    }
}
