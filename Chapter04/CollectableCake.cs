using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class CollectableCake : MonoBehaviour {

    //Stores the value of the cake in terms of Player's score
    public int cakeValue = 1;

    public AudioClip collectableSound;

    void OnTriggerEnter2D(Collider2D other) {
        //Check if the player collides with the angel's cake
        if (other.tag == "Player") {
            //If so, increase the number of cakes the player has collected (see in the next chapter)
            FindObjectOfType<UI_Score>().IncreaseScore(cakeValue);

            //Play the collectable sound
            GetComponent<AudioSource>().PlayOneShot(collectableSound);

            //Hide the cake by disabling the renderer
            GetComponent<Renderer>().enabled = false;

            //Then, destroy the cake after a delay (so the sound can finish to play)
            GameObject.Destroy(gameObject, collectableSound.length);

            //Destory this script, in case the player hits again the cake before that is destroyed
            Destroy(this);
        }
    }

}
