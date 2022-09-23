using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Create Wave")]
public class Wave : ScriptableObject {

    public GameObject enemy;
    public int enemyCount;
    public int enemyWaves;
}
