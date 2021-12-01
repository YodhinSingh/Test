using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SharkController : MonoBehaviour
{
    // public modifiers
    public float speed;
    public float jumpPower;

    // shark properties
    private float moveValue;
    private bool wantToJump;
    private bool onGround;
    private int direction;

    // components
    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;

    // Screen properties
    private float screenL, screenR;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();

        screenR = GeneralProperties.propertiesInstance.GetScreenBoundary().x;
        screenL = -screenR;

        direction = 1;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        Launch();
    }


    // handle shark movement
    private void UpdateMovement()
    {
        //rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);

        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        CheckBounds();
    }

    // have shark appear on other side of screen if they went too far left or right
    private void CheckBounds()
    {
        if (rb.position.x > screenR)
        {
            rb.position = new Vector2(screenL, rb.position.y);
        }
        else if (rb.position.x < screenL)
        {
            rb.position = new Vector2(screenR, rb.position.y);
        }
    }

    // launch the shark upwards with force
    private void Launch()
    {
        // only launch if on ground and if player presses jump button
        if (wantToJump && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            onGround = false;
        }
    }


    private void OnMove(InputValue value)   // get movement info from Unity's new input system
    {
        moveValue = value.Get<float>();
        if (moveValue == 0)
        {
            return;
        }

        direction = moveValue > 0 ? 1 : -1;

        spriteRender.flipX = direction == 1;
    }

    private void OnJump(InputValue value) // get jump info from Unity's new input system
    {
        wantToJump = value.isPressed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if shark is on 'ocean ground' so he can jump
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

}
