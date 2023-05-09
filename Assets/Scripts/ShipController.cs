using UnityEngine;

//Controlador del jugador
public class ShipController : MonoBehaviour {
    
    //Timer para la attack speed
    private float _lastShoot = -1.2f;
    //tipo de daño segun el arma equipada y los stats del objetivo
    private Vector3 _damageType;
    //Referencias de utilidad
    private Transform _shipTransform;
    private Rigidbody2D _rigidbody2D;
    private Camera _camera;
    private EquipmentManager _equipmentManager;

    //Inicializa al jugador
    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _equipmentManager = GetComponent<EquipmentManager>();
        _shipTransform = transform;
        _camera = Camera.main;
    }

    

    //Parte de la inicializacion, en el start para evitar conflictos
    private void Start() {
        //se rellena la pool con las balas necesarias
        _equipmentManager.PopulateBullets(_shipTransform, "player");
    }

    //Logica para el control del jugador durante el play
    private void Update() {
        //Control de direccion
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _rigidbody2D.velocity = new Vector2(horizontal, vertical) * _equipmentManager.GetMovementSpeed();
        //Observa al cursor, rota la nave
        LookAtCursor();
        //Control de disparo
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= _lastShoot) {
            _equipmentManager.Shoot(_shipTransform);
            _lastShoot = Time.time + _equipmentManager.GetAttackSpeed();
        }

        if (_equipmentManager.weapon.bulletAmount != 1)
        {
            _equipmentManager = GetComponent<EquipmentManager>();
        }
    }

    

    //Logica para que la nave rote en dirección al cursor
    private void LookAtCursor() {
        var direction = _camera.ScreenToWorldPoint(Input.mousePosition) - _shipTransform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        _shipTransform.rotation = rotation;
    }
}
