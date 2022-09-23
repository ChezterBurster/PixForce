using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private List<Wave> waves;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] spawnPoints;
    private int _waveCount;

    private IEnumerator SpawnEnemies() {
        for (var j = 0; j < waves[_waveCount].enemyWaves; j++) {
            var spawnPoint = Random.Range(0, spawnPoints.Length);
            for (var i = 0; i < waves[_waveCount].enemyCount; i++) {
                var position = spawnPoints[spawnPoint].position;
                var enemy = Instantiate(waves[_waveCount].enemy, position, Quaternion.identity);
                enemy.GetComponent<EnemyController>().player = player;
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    private void Start() {
        _waveCount = 0;
        StartCoroutine(SpawnEnemies());
    }
}
