using UnityEngine;

//Controla la logica de cada bala
public class BulletController : MonoBehaviour {
    //parent es quna referencia a quien dispara la bala, se usa en el pooling
    public EquipmentManager parent;
    //Tag para evitar fuego amigo
    public string father;
    //Son los tipos de daño que se pueden inflingir dependiendo del objetivo
    public float lifeDamage;
    public float shieldDamage;
    public bool ignoreShield;
    //Se usa para el timer que se encarga de hacer despawn a la bala
    private float _bornDate;
    //Referencias utiles
    private Rigidbody2D _rigidbody2D;
    private Transform _bulletTransform;

    //Se inicializa la bala
    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bulletTransform = transform;
    }
    
    //Aqui esta el timer, como estamos usando el pooling hay que resetearlo al activar la bala
    private void OnEnable() {
        _bornDate = Time.time;
    }
    
    //Logica que se encarga de la collision, las balas son triggers, no solidas
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag(father))
            return;
        var manager = col.GetComponent<EquipmentManager>();
        manager?.Damaged(this);//se asegura de que la entidad no haya muerto ya
        DestroyBullet();//reminder que no se destruye realmente
    }

    //un timer para que la bala no vuele al infinito
    private void Update() {
        if (Time.time >= _bornDate + 2) {
            DestroyBullet();//reminder que no se destruye realmente
        }
    }

    //Logica para aplicar la velocidad vectorial a la bala al ser disparada
    public void FireUp(Vector2 velocity, Vector3 damage, Transform origin) {
        _bulletTransform.position = origin.position;
        _bulletTransform.rotation = origin.rotation;
        _rigidbody2D.velocity = velocity * Random.Range(0.9f, 1.1f);
        lifeDamage = damage.x;
        shieldDamage = damage.y;
        ignoreShield = damage.z == 1f;
    }

    //De nuevo para el pooling, este metodo se usa para regresar la bala a su pool
    private void DestroyBullet() {
        parent.bullets.Add(this);
        _rigidbody2D.velocity = new Vector2(0f, 0f);
        gameObject.SetActive(false);
    }
}
