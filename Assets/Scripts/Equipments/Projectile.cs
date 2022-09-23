using UnityEngine;

namespace Equipments {
	
	[CreateAssetMenu(fileName = "NewProjectile", menuName = "Equipments/Projectile")]
	public class Projectile : ScriptableObject {
		
		public float lifeDamage;
		public float shieldDamage;
		public bool ignoreShield;
		public GameObject bulletPrefab;
	}
}
