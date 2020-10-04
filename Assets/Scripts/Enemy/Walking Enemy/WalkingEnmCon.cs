using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngineInternal;

public class WalkingEnmCon : MonoBehaviour
{
    bool walkingRight = true;
    float walkingSpeed = 1;
    SpriteRenderer spriteRen;

    private void Awake()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        if (UnityEngine.Random.Range(0, 2) == 1)
            walkingRight = false;
        if (walkingRight)
            spriteRen.flipX = true;

  
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (hitRight.collider.tag == "Wall" || hitRight.collider.tag == "Floor")
            {
                walkingRight = false;
                spriteRen.flipX = false;
            }
        }
        else if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "Wall" || hitLeft.collider.tag == "Floor")
            {
                walkingRight = true;
                spriteRen.flipX = true;
            }
        }

    }
}
