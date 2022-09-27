using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private List<Wave> waves;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] spawnPoints;

    private IEnumerator SpawnEnemies() {
        for (var k = 0; k < waves.Count; k++) {
            for (var j = 0; j < waves[k].enemyWaves; j++) {
                var spawnPoint = Random.Range(0, spawnPoints.Length);
                for (var i = 0; i < waves[k].enemyCount; i++) {
                    var position = spawnPoints[spawnPoint].position;
                    var enemy = Instantiate(waves[k].enemy, position, Quaternion.identity);
                    enemy.GetComponent<EnemyController>().player = player;
                    yield return new WaitForSeconds(0.5f);
                }
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }
}
