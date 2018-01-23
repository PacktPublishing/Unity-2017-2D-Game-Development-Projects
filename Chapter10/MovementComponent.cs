using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementComponent : MonoBehaviour {
    

    [SerializeField]
    private float moveForce = 360f;
    [SerializeField]
    private float maxSpeed = 5f;
    [SerializeField]
    private float jumpForce = 1000f;

    [SerializeField]
    private float jumpPadMultiplier = 2;

    private bool onJumpPad = false;

    [SerializeField]
    private Transform groundCheck;


    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Check if the groundCheck variable is set
        if(groundCheck == null) {
            Debug.LogError("Ground Check missing from the MovementComponent, please set one.");
            Destroy(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Set the Speed parameter in the Animation State Machine
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        //Set the Jump parameter in the Animation State Machine
        anim.SetBool("Jump", rb2d.velocity.y != 0);

        //Check in which direction the sprite should face and flip accordingly
        if (rb2d.velocity.x != 0)
            spriteRenderer.flipX = rb2d.velocity.x < 0;
    }


    public void MoveCharacter(float normalisedSpeed) {

        //If the max velocity is not reached, then...
        if(rb2d.velocity.x * normalisedSpeed < maxSpeed) {
            //... apply a force to the character
            rb2d.AddForce(Vector2.right * normalisedSpeed * moveForce);
        }

        //Set the velocity such as the x component is clamped, whereas the y component is the same
        float clampVelocityX = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(clampVelocityX, rb2d.velocity.y);

       // Debug.Log(rb2d.velocity.x);
    }


    public void Jump() {
        //Check if the character can jump
        Debug.Log(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")).collider);
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) {
            if (rb2d.velocity.y <= 0) {
                //Perform the jump (multiply by jumpPadMultiplier if onJumpPad is true)
                rb2d.AddForce(new Vector2(0f, onJumpPad ? jumpForce*jumpPadMultiplier : jumpForce));
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("JumpPad")) {
            onJumpPad = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("JumpPad")) {
            onJumpPad = false;
        }
    }
}
