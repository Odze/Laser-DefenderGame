using UnityEngine;

public class GameSessionScript : MonoBehaviour {
    
    private int score = 0;
    void Awake() {
        SetUpSingleton();
    }

    private void SetUpSingleton() {
        int numberGameSessions = FindObjectsOfType<GameSessionScript>().Length;
        if (numberGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() {
        return score;
    }

    public void AddToScore(int scoreValue) {
        score += scoreValue;
    }

    public void ResetScore() {
        Destroy(gameObject);
    }
}
