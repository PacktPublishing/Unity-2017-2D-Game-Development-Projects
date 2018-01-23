using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class WinningZone : MonoBehaviour {

    [SerializeField]
    private float timeDelay = 1.0f;

    [SerializeField]
    private string nextLevelToLoad = "level2"; //substitute with the next level to load. Be sure it is included in the build settings.

    private IEnumerator loadNextLevel() {
        //Show a winning message (left as exercise)

        //Wait timeDelay
        yield return new WaitForSeconds(timeDelay);

        //Restart Scene
        SceneManager.LoadScene(nextLevelToLoad); //substitute "level1" with the name of your level, also be sure to add the scene to the build settings
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //If the player enters within the Water Zone, then restart the scene
        if (collision.CompareTag("Player")) {
            StartCoroutine(loadNextLevel());
        }
    }
}
