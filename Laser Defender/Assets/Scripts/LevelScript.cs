using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {
    [SerializeField] private float delayInSeconds = 2f;
    
    public void LoadStartMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadGame() {
        int numberOfGameSessions = FindObjectsOfType<GameSessionScript>().Length;

        if (numberOfGameSessions >= 1) {
            SceneManager.LoadScene("Level"); 

            FindObjectOfType<GameSessionScript>().ResetScore();
        }
        else {
            SceneManager.LoadScene("Level"); 
        }
    }

    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame() {
        Application.Quit();
    }

    IEnumerator WaitAndLoad() {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
}
