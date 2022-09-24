using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Create Wave")]
public class Wave : ScriptableObject {

    //Controla las oleadas de enemigos
    //enemy hace referencia al prefab de un enemigo
    //enemycount, cantidad de enemigos a salir por oleada
    //enemywaves, Numero de oleadas.
    
    public GameObject enemy;
    public int enemyCount;
    public int enemyWaves;
}
