using UnityEngine;

//este controla los enemgos, planeaba cambiarlo para tener diferentes comportamientos
//Mejor hay que hacer otros dos para que sea uno para cada tipo de nave
public class EnemyController : MonoBehaviour {

    //Lo basico que debe tener cada entidad
    private Transform _enemyTransform;
    private Rigidbody2D _rigidbody2D;
    [HideInInspector] public Transform player;
    //Especialmente importante, controla los stats de la entidad.
    private EquipmentManager _equipmentManager;
    
    //Este es para el timer que controla el attack speed
    private float _lastShoot;
    
    //Son velocidades jeje
    private float _velocityX;
    private float _velocityY;
    
    private void Awake() {
        //Se inicializa la entidad
        _equipmentManager = GetComponent<EquipmentManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyTransform = transform;
        //Es el timer que mencione arriba
        _lastShoot = Time.time + 2;
    }

    private void Start() {
        //Aqui sigue la inicialización, es en el start para evitar conflictos con otras clases
        _velocityX = 1f;
        _velocityY = 1f;
        _equipmentManager.PopulateBullets(_enemyTransform, "enemy");
    }

    private void Update() {
        //Nos aseguramos de que exista una enitdad jugador en la escena
        if (player == null)
            return;
        
        //A partir de aqui está el comportamiento de la entidad
        //Para el enemigo generico consiste en hacer objetivo al jugador y moverse en diagonal por la escena
        LookAtPlayer();

        //Aqui se actualiza el timer
        if (Time.time >= _lastShoot) {
            _equipmentManager.Shoot(_enemyTransform);
            _lastShoot = Time.time + _equipmentManager.GetAttackSpeed();
        }
        
        //Esto mueve la entidad
        _rigidbody2D.velocity = GetVelocity() * _equipmentManager.GetMovementSpeed();
    }

    //Metodo para calcular la velocidad y tenga el comportamiento esperado que menciono en el update
    private Vector2 GetVelocity() {
        _velocityX = _enemyTransform.position.x >= 32f ? -1f : _enemyTransform.position.x <= -32f ? 1f : _velocityX;
        _velocityY = _enemyTransform.position.y >= 21f ? -2f : _enemyTransform.position.y <= -21f ? 2f : _velocityY;
        return new Vector2(_velocityX, _velocityY);
    }

    //Logica para hacer objetivo al jugador
    private void LookAtPlayer() {
        var direction = player.position - _enemyTransform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        _enemyTransform.rotation = rotation;
    }


}
