using UnityEngine;

[CreateAssetMenu(fileName = "NewProyectile", menuName = "Create Proyectile")]
public class Projectile : ScriptableObject {
	public float lifeDamage;
	public float shieldDamage;
	public bool ignoreShield;
	public GameObject bulletPrefab;
}
