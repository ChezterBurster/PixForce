using UnityEngine;
//namespace de los equipments, aqui va el codigo relacionado con los items
namespace Equipments {
	
	//archivo de datos de los proyectiles, se crea desde el inspector
	[CreateAssetMenu(fileName = "NewProjectile", menuName = "Equipments/Projectile")]
	public class Projectile : ScriptableObject {
		
		//atributos de los proyectiles
		public float lifeDamage;//el daño que hace a la vida
		public float shieldDamage;//Daño que hace a los escudos
		public bool ignoreShield;//si ignora o no el escudo
		public GameObject bulletPrefab;//el prefab de la bala pa disparar
	}
}
