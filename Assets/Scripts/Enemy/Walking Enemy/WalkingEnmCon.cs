using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngineInternal;

public class WalkingEnmCon : MonoBehaviour
{
    bool walkingRight = true;
    float walkingSpeed = 1;


    private void Awake()
    {
        if (UnityEngine.Random.Range(0, 2) == 1)
            walkingRight = false;
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

        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -Vector2.up, .1f);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, .1f);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -Vector2.right, .1f);

        if (hitDown.collider == null)
        {
            walkingRight = !walkingRight;
        }
        else if (hitRight.collider != null)
        {
            if (hitRight.collider.tag == "Wall" || hitRight.collider.tag == "Floor")
                walkingRight = false;
        }
        else if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "Wall" || hitLeft.collider.tag == "Floor")
                walkingRight = true;
        }

    }
}
