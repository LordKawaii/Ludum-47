using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyCon : MonoBehaviour
{
    [SerializeField]
    float flySpeed = 5f;
    [SerializeField]
    float minTimeToSpoop = 1;
    [SerializeField]
    float maxTimeToSpoop = 3;
    [SerializeField]
    List<AudioClip> spoops;

    Rigidbody2D rb2d;
    SpriteRenderer spriteRend;

    AudioSource audioS;

    bool hasSeenPlayer = false;
    Vector3 startingPos;
    Vector3 randomSpot;
    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        startingPos = transform.position;
        randomSpot = transform.position;
        audioS = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(LazyFlying(startingPos, 1f, 1f, 1f));
        StartCoroutine(PlaySpoop(maxTimeToSpoop, maxTimeToSpoop, spoops));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = randomSpot - transform.position;
        if (transform.position != randomSpot)
            rb2d.AddForce(direction);
        if (direction.x > 0)
            spriteRend.flipX = true;
        else
            spriteRend.flipX = false;

    }

    Vector2 PickRandomSpot(float range, Vector2 pos)
    {
        float newX = UnityEngine.Random.Range(pos.x - range, pos.x + range);
        float newY = UnityEngine.Random.Range(pos.y - range, pos.y + range);

        Vector2 nextSpot = new Vector2(newX, newY);
        return nextSpot;
    }

    IEnumerator PlaySpoop (float minTime, float maxTime, List<AudioClip> spoops)
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTime, maxTime));
            audioS.pitch = UnityEngine.Random.Range(-1f, 1f);
            audioS.PlayOneShot(spoops[UnityEngine.Random.Range(0, spoops.Count)]);
        }
    }

    IEnumerator LazyFlying(Vector3 startPos, float minTime, float maxTime, float range)
    {
        while (!hasSeenPlayer)
        {
            if (Vector3.Distance(startingPos, randomSpot) > range * 2)
                randomSpot = PickRandomSpot(range, startingPos);
            else
                randomSpot = PickRandomSpot(range, transform.position);

            float timeTillNextPos = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(timeTillNextPos);
            
        }
    }
}
