using UnityEngine;
//namespace de los equipments, aqui va el codigo relacionado con los items
namespace Equipments {
    
    //Archivo de datos que contiene la info de cada item equipable, dropeable etc, se crea desde el inspector
    [CreateAssetMenu(fileName = "New Equipment", menuName = "Equipments/Equipment")]
    public class Equipment : ScriptableObject {
        
        //Stats que puede otorgar dicho equipo
        [Range(0f, 50f)] public int life;
        [Range(0f, 50f)] public int defense;
        [Range(0f, 50f)] public int speed;
        [Range(0f, 50f)] public float attackSpeed;
        //Referencias para las entidades
        public EquipmentType equipmentType;
        public GameObject equipmentPrefab;//Este seria el objeto al dropearse, de los cofres que hizo frank

        //Metodo para aplicar los stats a la entidad
        public void AddStats(EquipmentManager equipmentManager) {
            equipmentManager.life += life;
            equipmentManager.defense += defense;
            equipmentManager.speed += speed;
            equipmentManager.attackSpeed += attackSpeed;
        }
        
        //Metodo para dropear, incompleto, lo puedes rehacer
        public void OnDrop(Vector3 position) {
            var equipment = Instantiate(equipmentPrefab, position, Quaternion.identity);
            equipment.GetComponent<DropManager>().equipment = this;
        }

    }

    //Enum para los tipos de items
    public enum EquipmentType {
        Body,
        Wings,
        Engine,
        Cabine
    }
    
}