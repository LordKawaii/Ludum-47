using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngineInternal;

public class WalkingEnmCon : MonoBehaviour
{
    bool walkingRight = true;
    
    [SerializeField]
    float walkingSpeed = 1;
    
    SpriteRenderer spriteRen;
    
    [SerializeField]
    float minTimeToSpoop = 1;
    
    [SerializeField]
    float maxTimeToSpoop = 3;
    
    [SerializeField]
    List<AudioClip> spoops;

    AudioSource audioS;

    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
        spriteRen = GetComponent<SpriteRenderer>();
        if (UnityEngine.Random.Range(0, 2) == 1)
            walkingRight = false;
        if (walkingRight)
            spriteRen.flipX = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySpoop(maxTimeToSpoop, maxTimeToSpoop, spoops));

    }

    private void FixedUpdate()
    {
        if (walkingRight)
        {
            transform.position = new Vector2(transform.position.x + walkingSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - walkingSpeed * Time.deltaTime, transform.position.y);
        }

        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -Vector2.up, 2f);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 1.5f);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -Vector2.right, 1.5f);

        if (hitDown.collider == null)
        {
            walkingRight = !walkingRight;
            if (walkingRight)
                spriteRen.flipX = true;
            else
                spriteRen.flipX = false;
        }
        else if (hitRight.collider != null)
        {
            Debug.Log(hitRight.collider.name);
            if (hitRight.collider.tag == "Wall" || hitRight.collider.tag == "Floor")
            {
                walkingRight = false;
                spriteRen.flipX = false;
            }
        }
        else if (hitLeft.collider != null)
        {
            Debug.Log(hitLeft.collider.name);
            if (hitLeft.collider.tag == "Wall" || hitLeft.collider.tag == "Floor")
            {
                
                walkingRight = true;
                spriteRen.flipX = true;
            }
        }

    }
    IEnumerator PlaySpoop(float minTime, float maxTime, List<AudioClip> spoops)
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTime, maxTime));
            audioS.pitch = UnityEngine.Random.Range(-.5f, 1.5f);
            audioS.PlayOneShot(spoops[UnityEngine.Random.Range(0, spoops.Count)]);
        }
    }
}
