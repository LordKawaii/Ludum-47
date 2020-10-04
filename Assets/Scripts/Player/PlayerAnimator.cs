using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour
{
    Animator playerAni;
    SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        playerAni = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipSprite(bool fliped)
    {
        spriteRend.flipX = fliped;
    }

    public void SetWalk(bool walking)
    {
        playerAni.SetBool("Walking", walking);
    }

    public void SetJump(bool jumping)
    {
        playerAni.SetBool("Jumping", jumping);
    }

    public void TriggerHit()
    {
        playerAni.SetTrigger("Hit");
    }
}
