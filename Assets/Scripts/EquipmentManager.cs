using System.Collections.Generic;
using Equipments;
using UnityEngine;

//Esta clase se usa para controlar las stats de cualquier entidad
public class EquipmentManager : MonoBehaviour {
    
    //items que se pueden equipar, serializados para acceder desde el inspector
    //Los items se usan tambien para controlar los stats de entidades no jugador
    private List<Equipment> _equipments;
    [SerializeField] private Equipment body;
    [SerializeField] private Equipment engine;
    [SerializeField] private Equipment wings;
    [SerializeField] private Equipment cabine;
    public Weapon weapon;


    //El proyectil es el tipo de bala que dispara
    [SerializeField] private Projectile projectile;
    //Esta variable se usa para determinar desde el inspector la posicion del cañon de cada nave para que coincidan
    [SerializeField] private Vector2 cannonPosition;
    //Controla la velocidad de la bala, considera moverlo a la clase Projectile
    [SerializeField] private float bulletVelocity;
    
    //Variables para procesar stats de la entidad
    private float _life;
    private float _shield;
    private float _movementSpeed;
    private float _attackSpeed;
    //version publica de los stats
    public float life;
    public float defense;
    public float speed;
    public float attackSpeed;
    
    //Variables de utilidad
    private GameObject _bulletPrefab;
    private Transform _transform;
    //Estoy usando un patron de diseño que se llama object pooling o algo así, paro eso es esta lista
    [HideInInspector] public List<BulletController> bullets;
    //Referencia a las posiciones de los cañones para disparar correctamente
     public List<Transform> cannonPositions;
    //Esta variable es solo usada por entidades jugador, considera mudarla
    public Inventory inventory;
    
    //Inicialización de la entidad
    private void Awake() {
        _transform = transform;
        _equipments = new List<Equipment>();
        EquipUp();
        GetStatsFromEquipments();
        CalculateStats();
        RefreshWeapon();
        _bulletPrefab = projectile.bulletPrefab;
    }

    //Obtiene referencias para los diferentes items equipados
    private void EquipUp() {
        _equipments.Add(body);
        _equipments.Add(engine);
        _equipments.Add(wings);
        _equipments.Add(cabine);
    }

    public void RefreshWeapon()
    {
        foreach (var cannon  in cannonPositions)
        {
            Destroy(cannon.gameObject);
        }
        cannonPositions.Clear();
        var position = _transform.position;
        weapon.SetWeapon(new Vector2(position.x + cannonPosition.x, position.y + cannonPosition.y), _transform, this);
    }

    //Geters para las variables locales y así
    public float GetMovementSpeed() {
        return _movementSpeed;
    }
    
    public float GetAttackSpeed() {
        return _attackSpeed;
    }

    //Usa los stats de un item para sumarlos a los stats totales
    private void CalculateStats() {
        _life = life * 1.5f;
        _shield = defense * 2;
        _movementSpeed = speed * 0.4f;
        _attackSpeed = 2 - (attackSpeed / 100);
    }

    //Suma los stats de cada item equipado a los stats totales
    private void GetStatsFromEquipments() {
        foreach (var equipment in _equipments) {
            equipment.AddStats(this);
        }
    }
    
    //Te acuerdas lo del pooling, este metodo es para eso, obtiene las balas necesarias para cada entidad.
    public void PopulateBullets(Transform shipTransform, string father) {
        for (var i = 0; i < attackSpeed * 10 * cannonPositions.Count; i++) {
            var bullet = Instantiate(_bulletPrefab, shipTransform.position, Quaternion.identity).GetComponent<BulletController>();
            bullet.parent = this;
            bullet.father = father;
            bullets.Add(bullet);
            bullet.gameObject.SetActive(false);
        }
    }

    //Logica para disparar
    public void Shoot(Transform shipTransform) {
        foreach (var cannon in cannonPositions) {
            var bullet = bullets[0];
            bullet.gameObject.SetActive(true);
            bullet.FireUp(shipTransform.up * bulletVelocity, GetDamage(), cannon);
            bullets.Remove(bullet);
        }
    }
    
    //Logica para recibir daño, incluye morir y así
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
    
    

    //Calcula el daño que se va a recibir
    private Vector3 GetDamage() {
        var ignoreShield = projectile.ignoreShield ? 1f : 0f;
        return new Vector3(weapon.damage * projectile.lifeDamage, weapon.damage * projectile.shieldDamage, ignoreShield);
    }
}
