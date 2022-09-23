using UnityEngine;

namespace Equipments {
    
    [CreateAssetMenu(fileName = "New Equipment", menuName = "Equipments/Equipment")]
    public class Equipment : ScriptableObject {
    
        public int life;
        public int defense;
        public int speed;
        public float attackSpeed;
        public GameObject equipmentPrefab;

        public void AddStats(EquipmentManager equipmentManager) {
            equipmentManager.life += life;
            equipmentManager.defense += defense;
            equipmentManager.speed += speed;
            equipmentManager.attackSpeed += attackSpeed;
        }

        public void OnDrop(Vector3 position) {
            var equipment = Instantiate(equipmentPrefab, position, Quaternion.identity);
            equipment.GetComponent<DropManager>().equipment = this;
        }

    }
    
}