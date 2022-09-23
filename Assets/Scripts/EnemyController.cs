using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Transform _enemyTransform;
    private Rigidbody2D _rigidbody2D;
    private EquipmentManager _equipmentManager;
    [HideInInspector] public Transform player;

    private float _lastShoot;
    private float _velocityX;
    private float _velocityY;
    
    private void Awake() {
        _equipmentManager = GetComponent<EquipmentManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyTransform = transform;
        _lastShoot = Time.time + 2;
    }

    private void Start() {
        _velocityX = 1f;
        _velocityY = 1f;
        _equipmentManager.PopulateBullets(_enemyTransform, "enemy");
    }

    private void Update() {
        if (player == null)
            return;
        
        LookAtPlayer();

        if (Time.time >= _lastShoot) {
            _equipmentManager.Shoot(_enemyTransform);
            _lastShoot = Time.time + _equipmentManager.GetAttackSpeed();
        }
            

        _rigidbody2D.velocity = GetVelocity() * _equipmentManager.GetMovementSpeed();
    }

    private Vector2 GetVelocity() {
        _velocityX = _enemyTransform.position.x >= 32f ? -1f : _enemyTransform.position.x <= -32f ? 1f : _velocityX;
        _velocityY = _enemyTransform.position.y >= 21f ? -2f : _enemyTransform.position.y <= -21f ? 2f : _velocityY;
        return new Vector2(_velocityX, _velocityY);
    }

    private void LookAtPlayer() {
        var direction = player.position - _enemyTransform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        _enemyTransform.rotation = rotation;
    }


}
