using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour {

    //Reference to the Text component, set in the Start() function
    private Text uiText;

    //Current score of the player
    private int score;

    //Points required to the next level (set in the Inspector)
    [SerializeField]
    private int pointsToNextLevel;

    //Reference to the game over screen GameObject (set in the Inspector)
    [SerializeField]
    private GameObject gameOverScreen;

	// Use this for initialization
	void Start () {
        //Get a reference to the Text component
        uiText = GetComponent<Text>();

        //Get the sum of all the cake values around the level
        foreach(CollectableCake cake in FindObjectsOfType<CollectableCake>()) {
            pointsToNextLevel += cake.cakeValue;
        }
	}

    public void IncreaseScore(int points) {
        //Increase the points
        score += points;

        //Check if the player has collected all the points to the next level
        if(score >= pointsToNextLevel) {
            //If so, show the game over screen
            gameOverScreen.SetActive(true);

            //Disable the player controller, so the player cannot move while the Gameover screen is on
            FindObjectOfType<PlayerController>().enabled = false;
        }

        //Update the Score count
        uiText.text = "Score: " + score.ToString();
    }
}
