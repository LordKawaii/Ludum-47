using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    [SerializeField]
    int health = 2;

    [SerializeField]
    List<AudioClip> owies;

    PlayerAnimator playerAni;
    AudioSource au;


    // Start is called before the first frame update
    void Start()
    {
        playerAni = GetComponent<PlayerAnimator>();
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitPlayer()
    {
        playerAni.TriggerHit();
        au.pitch = UnityEngine.Random.Range(-1f, 1f);
        au.PlayOneShot(owies[UnityEngine.Random.Range(0, owies.Count)]);
        health--;
        if (health > 0)
        GameCon.Instance.SetHealthIco(health);
        if (health == 0)
            GameCon.Instance.RestartLoop();
    }
}
