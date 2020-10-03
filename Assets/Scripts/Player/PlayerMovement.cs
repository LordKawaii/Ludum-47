using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerControlls.IPlayerMovementActions
{
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float maxSpeed = 20f;
    [SerializeField]
    float jumpForce = 100f;

    bool canJump = true;

    Vector2 moveForce;

    Rigidbody2D rb2d;

    public PlayerControlls controlls;
    
    private void Awake()
    {
        controlls = new PlayerControlls();
        controlls.PlayerMovement.SetCallbacks(this);
        moveForce = Vector2.zero;
        if (rb2d == null)
            rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(moveForce * moveSpeed);
        if (rb2d.velocity.magnitude > maxSpeed)
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, .1f);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Floor")
            {
                canJump = true;
            }
        }
    }

    private void OnEnable()
    {
        controlls.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        controlls.PlayerMovement.Disable();
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        //Vector2 force = new Vector2(1, 0);
        if (context.phase == InputActionPhase.Performed)
            moveForce = new Vector2(1, 0);
        else
            moveForce = Vector2.zero;
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            moveForce = new Vector2(-1, 0);
        else
            moveForce = Vector2.zero;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (canJump)
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
                canJump = false;
            }
        }

    }

    public void OnDuck(InputAction.CallbackContext context)
    {
    }
}
