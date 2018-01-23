using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyControllerSmarterAttacker : MonoBehaviour {

    public float speedX = 10.0f;
    public float speedY = -10.0f;

    public float boundX = 10.0f;

    public float reloadTime = 1.0f;
    private float lastTimeShot = 0f;
    public GameObject bulletPrefab;

    private Transform playerTransform;

    public float shootSensitivity;

    public GameObject explosionPrefab;

    private Rigidbody2D rigidBody;


    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();

        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    void FixedUpdate() {
        //Get the new position of our Enemy. On X, move left and right; on Y slowly get down.
        var x = boundX * Mathf.Sin(Time.deltaTime * speedX);
        var y = transform.position.x + Time.deltaTime * speedY;

        //Set the position of our character through the RigidBody2D component (since we are using physics)
        rigidBody.MovePosition(new Vector2(x, transform.position.y));

        // Fire as soon as the reload time is expired
        if(Time.time - lastTimeShot > reloadTime) {
            //Check if the enemy is "close" on the x-axis to the player
            if (Mathf.Abs(playerTransform.position.x - transform.position.x) < shootSensitivity) {
                //Set the current time as the last time the spaceship has fired
                lastTimeShot = Time.time;

                //Create the bullet
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    public void Hit(Vector3 hitCoordinates) {
        //Create an explosion on the coordinates of the hit.
        Instantiate(explosionPrefab, hitCoordinates, Quaternion.identity);
    }
}
