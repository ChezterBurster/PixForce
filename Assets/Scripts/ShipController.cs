using UnityEngine;

public class ShipController : MonoBehaviour {
    
    
    private float _lastShoot = -1.2f;
    private Vector3 _damageType;
    private Transform _shipTransform;
    private Rigidbody2D _rigidbody2D;
    private Camera _camera;
    private EquipmentManager _equipmentManager;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _equipmentManager = GetComponent<EquipmentManager>();
        _shipTransform = transform;
        _camera = Camera.main;
    }

    private void Start() {
        _equipmentManager.PopulateBullets(_shipTransform, "player");
    }

    private void Update() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _rigidbody2D.velocity = new Vector2(horizontal, vertical) * _equipmentManager.GetMovementSpeed();
        
        LookAtCursor();

        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= _lastShoot) {
            _equipmentManager.Shoot(_shipTransform);
            _lastShoot = Time.time + _equipmentManager.GetAttackSpeed();
        }
    }

    private void LookAtCursor() {
        var direction = _camera.ScreenToWorldPoint(Input.mousePosition) - _shipTransform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        _shipTransform.rotation = rotation;
    }
}
