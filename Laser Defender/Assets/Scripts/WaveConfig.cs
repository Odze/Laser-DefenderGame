using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wawe Config")]
public class WaveConfig : ScriptableObject {
    
    [SerializeField] private GameObject enemyPreFab;
    [SerializeField] private GameObject pathPreFab;
    [SerializeField] private float timeBettweenSpawns = 0.5f;
    [SerializeField] private float spawnRandomFactor = 0.3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 5f;

    public GameObject GetEnemyPreFab() { return enemyPreFab; }
    public float GetTimeBetweenSpawns () { return timeBettweenSpawns; }
    public float GetSpawnRandomFactor () { return spawnRandomFactor; }
    public int GetNumberOfEnemies () {return numberOfEnemies; }
    public float GetmoveSpeed () { return moveSpeed; }
    
    public List<Transform> GetWayPoints() {
        var waweWayPoints = new List<Transform>();

        foreach (Transform waypoint in pathPreFab.transform) {
            waweWayPoints.Add(waypoint);
        }
        
        return waweWayPoints;
    }
    
}
