using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour {

    public int lives;
    public int maxNumberOfLives = 3;

    private GameObject[] hearts;

	// Use this for initialization
	void Start () {
        //Set the initial number of lives to its maximum
        lives = maxNumberOfLives;

        //Initialise the array of hearts
        hearts = new GameObject[maxNumberOfLives];

        //Cycle among children and get the hearts we need
        for(int i = 0; i<maxNumberOfLives; i++) {
            hearts[i] = transform.GetChild(i).gameObject;
        }
	}

    public void AddLife() {
        //Increment the number of lives
        lives++;

        //Clamp the number of lives to the maximum
        if(lives > maxNumberOfLives) {
            lives = maxNumberOfLives;
        }

        //Update the Graphics
        UpdateGraphics();

    }

    public void RemoveLife() {
        //Decrement the number of lives
        lives--;

        //Check if the number of lives is zero (or less) and trigger Game Over, such as reload the level
        if(lives <= 0) {
            //Trigger Game Over, in this case reload current level
            UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
        }

        //Update the Graphics
        UpdateGraphics();
    }
	


	public void UpdateGraphics () {
        //For each heart, check if it should be shown or not, based on the number of lives
		for(int i= 0; i<maxNumberOfLives; i++) {
            if(i >= lives) {
                hearts[i].SetActive(false);
            } else {
                hearts[i].SetActive(true);
            }
        }
	}
}
