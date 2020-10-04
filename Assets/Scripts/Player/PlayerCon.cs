using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    [SerializeField]
    int health = 2;

    PlayerAnimator playerAni;

    // Start is called before the first frame update
    void Start()
    {
        playerAni = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitPlayer()
    {
        playerAni.TriggerHit();
        health--;
        if (health > 0)
        GameCon.Instance.SetHealthIco(health);
        if (health == 0)
            GameCon.Instance.RestartLoop();
    }
}
