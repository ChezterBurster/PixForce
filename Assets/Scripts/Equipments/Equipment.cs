using UnityEngine;

namespace Equipments {
    
    [CreateAssetMenu(fileName = "New Equipment", menuName = "Equipments/Equipment")]
    public class Equipment : ScriptableObject {
    
        [Range(0f, 50f)] public int life;
        [Range(0f, 50f)] public int defense;
        [Range(0f, 50f)] public int speed;
        [Range(0f, 50f)] public float attackSpeed;
        public EquipmentType equipmentType;
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

    public enum EquipmentType {
        Body,
        Wings,
        Engine,
        Cabine
    }
    
}