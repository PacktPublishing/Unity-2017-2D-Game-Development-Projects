using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;

    private Rigidbody2D rigidBody;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate () {
        //Get the new position of our character
        var x = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //Set the position of our character throught the RigidBody2D component (since we are using physics)
        rigidBody.MovePosition(new Vector2(x, y));
    }
}
