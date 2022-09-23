using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Equipments/Weapon")]
public class Weapon : ScriptableObject {
    
    public float damage;
    [Range(1, 5)]
    public int bulletAmount;
    public GameObject cannonPrefab;

    public void SetWeapon(Vector2 position, Transform parent, EquipmentManager manager) {
        
        for (var i = 0; i < bulletAmount; i++) {
            var cannon = Instantiate(cannonPrefab, position, Quaternion.identity, parent);
            manager.cannonPositions.Add(cannon.transform);
        }

        switch (bulletAmount) {
            case > 1 and < 4:
                manager.cannonPositions[0].position = new Vector2(position.x - 0.5f, position.y);
                manager.cannonPositions[1].position = new Vector2(position.x + 0.5f, position.y);
                break;
            case > 4:
                manager.cannonPositions[0].position = new Vector2(position.x - 0.5f, position.y);
                manager.cannonPositions[1].position = new Vector2(position.x + 0.5f, position.y);
                manager.cannonPositions[2].position = new Vector2(position.x - 1f, position.y);
                manager.cannonPositions[3].position = new Vector2(position.x + 1f, position.y);
                break;
        }
    }
}
