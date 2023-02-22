using UnityEngine;

//Es un archivo que tiene la información de cada oleada, se crea desde el inspector
[CreateAssetMenu(fileName = "NewWave", menuName = "Create Wave")]
public class Wave : ScriptableObject {
    
    //enemy hace referencia al prefab de un enemigo
    //enemycount, cantidad de enemigos a salir por tanda
    //enemywaves, numero de tandas por oleada.
    
    public GameObject enemy;
    public int enemyCount;
    public int enemyWaves;
}
