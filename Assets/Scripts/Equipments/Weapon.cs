using UnityEngine;
//Namespace de los items
namespace Equipments {
    
    //Archivo de datos para las armas, se crea desde el inspector
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Equipments/Weapon")]
    public class Weapon : ScriptableObject {
        //daño que va a aplicar
        public float damage;
        [Range(1, 5)]//Rango de 1 a 5, numero de balas que se disparan por disparo
        public int bulletAmount;
        //referencia a los cañones, es un prefab vacio, tal vez hay una mejor manera de hacer esto pero xd
        public GameObject cannonPrefab;

        //Se usa para inicializar el arma de la entidad
        public void SetWeapon(Vector2 position, Transform parent, EquipmentManager manager) {
        
            //Se encarga de colocar cada cañon en su posicion dependiendo del numero de balas por disparo
            for (var i = 0; i < bulletAmount; i++) {
                var cannon = Instantiate(cannonPrefab, position, parent.rotation, parent);
                manager.cannonPositions.Add(cannon.transform);
                
            }
            //Es parte de la logica para las posiciones de los disparos
            switch (bulletAmount) {
                case > 1 and < 4:
                    manager.cannonPositions[0].position = new Vector2(position.x - parent.right.x, position.y - parent.right.y);
                    manager.cannonPositions[1].position = new Vector2(position.x + parent.right.x, position.y + parent.right.y);
                    break;
                case >= 4:
                    manager.cannonPositions[0].position = new Vector2(position.x - 1.0f, position.y);
                    manager.cannonPositions[1].position = new Vector2(position.x + 1.0f, position.y);
                    manager.cannonPositions[2].position = new Vector2(position.x - 2.0f, position.y);
                    manager.cannonPositions[3].position = new Vector2(position.x + 2.0f, position.y);
                    break;
                
                
                //mandar alv to-do  este pedo xd y poner game objects
                // todo poner cosas chidas ry for taking  
            } 
        }
    }
}
