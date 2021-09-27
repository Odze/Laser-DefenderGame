using TMPro;
using UnityEngine;

public class ScoreDisplayScript : MonoBehaviour {
   
   private TextMeshProUGUI Scoretext;
   private GameSessionScript gameSession;
   private void Start() {
      Scoretext = GetComponent<TextMeshProUGUI>();
      gameSession = FindObjectOfType<GameSessionScript>();
   }

   private void Update() {
      Scoretext.text = gameSession.GetScore().ToString();
   }
}
