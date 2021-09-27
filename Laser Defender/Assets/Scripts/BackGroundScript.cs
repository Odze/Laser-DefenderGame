using UnityEngine;

public class BackGroundScript : MonoBehaviour {
    
    [SerializeField] private float backgroundScrollSpeed = 0.03f;

    private Material myMaterial;
    private Vector2 offSet;
    
    void Start() {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }
    
    void Update() {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
