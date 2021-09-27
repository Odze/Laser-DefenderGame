using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingScript : MonoBehaviour {
    
    private WaveConfig waveConfig;
    private List<Transform> wayPoints;
    private int wayPointIndex = 0;

    private void Start() {
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    private void Update() {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }
    
    private void Move() {
        if (wayPointIndex <= wayPoints.Count -1) {
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisFrame = waveConfig.GetmoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards (
                transform.position,
                targetPosition,
                movementThisFrame
            );
            if (transform.position == targetPosition) {
                wayPointIndex++;
            }
        }
        else {
            Destroy(gameObject);
        }
    }
}
