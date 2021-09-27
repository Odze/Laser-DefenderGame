using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    [Header("Player")]
    [SerializeField] private float moveMentSpeed = 10f;
    [SerializeField] private float padding = 1f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserSpeed = 10f;
    [SerializeField] private float projetileFiringPeriod  = 0.1f;
    [SerializeField] private float health = 100;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField][Range(0,1)] private float deathSoundVolume = 0.75f;
    [SerializeField][Range(0,1)] private float shootSoundVolume = 0.75f;
    
    private Coroutine firingCoroutine;
    private float xMin;
    private float xMax;
    
    // Start is called before the first frame update
    void Start() {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update() {
        Move();
        Fire();
    }

    IEnumerator FireContinuosly() {
        while (true) {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projetileFiringPeriod);
        }
    }
    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveMentSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }

        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoroutine);
        }
    }
    
    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }
    
    private void Die() {
        FindObjectOfType<LevelScript>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        
        if (health <= 0) {
            Die();
        }
    }
}
