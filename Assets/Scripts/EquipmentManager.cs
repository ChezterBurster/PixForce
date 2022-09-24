using System.Collections.Generic;
using Equipments;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {
    
    
    [SerializeField] private Equipment body;
    [SerializeField] private Equipment engine;
    [SerializeField] private Equipment wings;
    [SerializeField] private Equipment cabine;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Projectile projectile;
    [SerializeField] private Vector2 cannonPosition;
    [SerializeField] private float bulletVelocity;
    
    private List<Equipment> _equipments;
    private GameObject _bulletPrefab;
    private Transform _transform;
    private float _life;
    private float _shield;
    private float _movementSpeed;
    private float _attackSpeed;
    
    public List<BulletController> bullets;
    public Inventory inventory;
    public List<Transform> cannonPositions;
    
    public float life;
    public float defense;
    public float speed;
    public float attackSpeed;
   
    private void Awake() {
        _transform = transform;
        _equipments = new List<Equipment>();
        EquipUp();
        GetStatsFromEquipments();
        CalculateStats();
        var position = _transform.position;
        weapon.SetWeapon(new Vector2(position.x + cannonPosition.x, position.y + cannonPosition.y), _transform, this);
        _bulletPrefab = projectile.bulletPrefab;
    }

    private void EquipUp() {
        _equipments.Add(body);
        _equipments.Add(engine);
        _equipments.Add(wings);
        _equipments.Add(cabine);
    }

    public float GetMovementSpeed() {
        return _movementSpeed;
    }
    
    public float GetAttackSpeed() {
        return _attackSpeed;
    }

    private void CalculateStats() {
        _life = life * 1.5f;
        _shield = defense * 2;
        _movementSpeed = speed * 0.4f;
        _attackSpeed = 2 - (attackSpeed / 100);
    }

    private void GetStatsFromEquipments() {
        foreach (var equipment in _equipments) {
            equipment.AddStats(this);
        }
    }
    
    public void PopulateBullets(Transform shipTransform, string father) {
        for (var i = 0; i < attackSpeed * 10 * cannonPositions.Count; i++) {
            var bullet = Instantiate(_bulletPrefab, shipTransform.position, Quaternion.identity).GetComponent<BulletController>();
            bullet.parent = this;
            bullet.father = father;
            bullets.Add(bullet);
            bullet.gameObject.SetActive(false);
        }
    }

    public void Shoot(Transform shipTransform) {
        foreach (var cannon in cannonPositions) {
            var bullet = bullets[0];
            bullet.gameObject.SetActive(true);
            bullet.FireUp(shipTransform.up * bulletVelocity, GetDamage(), cannon);
            bullets.Remove(bullet);
        }
    }
    
    public void Damaged(BulletController bullet) {
        if (bullet.ignoreShield) {
            _life -= bullet.lifeDamage;
        }else {
            if (_shield > 0)
                _shield -= bullet.shieldDamage;
            else
                _life -= bullet.lifeDamage;
        }

        if (_life <= 0f) {
            Destroy(gameObject);
        }
    }

    private Vector3 GetDamage() {
        var ignoreShield = projectile.ignoreShield ? 1f : 0f;
        return new Vector3(weapon.damage * projectile.lifeDamage, weapon.damage * projectile.shieldDamage, ignoreShield);
    }
}
