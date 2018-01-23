using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class WaterZone : MonoBehaviour {

    [SerializeField]
    private float timeDelay = 1.0f;

    private IEnumerator restartScene() {
        //Show a gameover message (left as exercise)

        //Wait timeDelay
        yield return new WaitForSeconds(timeDelay);

        //Restart Scene
        SceneManager.LoadScene("level1"); //substitute "level1" with the name of your level, also be sure to add the scene to the build settings
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //If the player enters within the Water Zone, then restart the scene
        if (collision.CompareTag("Player")) {
            StartCoroutine(restartScene());
        }
    }
}
