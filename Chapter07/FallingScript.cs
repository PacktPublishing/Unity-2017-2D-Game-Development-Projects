using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour {

    public float speed = 1.3f;

    public float timeBeforeDestruction = 10.0f;

    // Use this for initialization
    void Start () {
        //Destroy the falling object after timeBeforeDestruction
        Destroy(gameObject, timeBeforeDestruction);
    }
	
	// Update is called once per frame
	void Update () {
        //Move the object downwards
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
