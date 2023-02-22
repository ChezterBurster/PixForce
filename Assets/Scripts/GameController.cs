using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase controla el gameplay de cada nivel
public class GameController : MonoBehaviour {

    //Referencias a las Oleadas, Jugador y los spawns
    [SerializeField] private List<Wave> waves;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] spawnPoints;

    //Logica que spawnea enemigos a lo largo del tiempo
    private IEnumerator SpawnEnemies() {
        //Empieza una oleada
        for (var k = 0; k < waves.Count; k++) {
            //Empieza una tanda de enemigos
            for (var j = 0; j < waves[k].enemyWaves; j++) {
                var spawnPoint = Random.Range(0, spawnPoints.Length);
                //spawnea cierto nuemero de enemigos por esta tanda
                for (var i = 0; i < waves[k].enemyCount; i++) {
                    var position = spawnPoints[spawnPoint].position;
                    var enemy = Instantiate(waves[k].enemy, position, Quaternion.identity);
                    enemy.GetComponent<EnemyController>().player = player;
                    //tiempo entre cada enemigo
                    yield return new WaitForSeconds(0.5f);
                }
                //Tiempo entre cada tanda
                yield return new WaitForSeconds(2f);
            }
            //Tiempo entre Oleada, lo puedes cambiar hasta que cada enemigo de la ultima oleada haya muerto si quieres
            yield return new WaitForSeconds(2f);
        }
    }

    //Aqui empieza el nivel, si quisieras un contador de "3,2,1" por ejemplo, se pondría aquí
    private void Start() {
        StartCoroutine(SpawnEnemies());
    }
}
