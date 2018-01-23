using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSatellite : MonoBehaviour {

    public float speed = 3f;
    public float radius = 1f;
	
	// Update is called once per frame
	void Update () {
        //Calculate the new x and y of the circular motion
        var x = radius * Mathf.Cos(speed * Time.time);
        var y = radius * Mathf.Sin(speed * Time.time);

        //Assign the new position to the object transform
        transform.localPosition =  new Vector3(x, y, 0f);
	}
}
