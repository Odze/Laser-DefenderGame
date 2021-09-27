using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private int startingWawe = 0;
    [SerializeField] private bool looping = false;
    
    IEnumerator Start() {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves() {
        for (int waveIdex = startingWawe; waveIdex < waveConfigs.Count; waveIdex++) {
            var currentWawe = waveConfigs[waveIdex];
            yield return StartCoroutine(SpawnAllEnemiesInWawe(currentWawe));
        } 
    }

    private IEnumerator SpawnAllEnemiesInWawe(WaveConfig waveConfig) {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++) {
            var newEnemey = Instantiate (
                waveConfig.GetEnemyPreFab(),
                waveConfig.GetWayPoints()[0].transform.position,
                Quaternion.identity);
            
            newEnemey.GetComponent<EnemyPathingScript>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
