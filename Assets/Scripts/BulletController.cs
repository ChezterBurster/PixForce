using UnityEngine;

public class BulletController : MonoBehaviour {
    public EquipmentManager parent;
    public float lifeDamage;
    public float shieldDamage;
    public bool ignoreShield;
    public string father;
    private float _bornDate;
    private Rigidbody2D _rigidbody2D;
    private Transform _bulletTransform;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bulletTransform = transform;
    }

    private void OnEnable() {
        _bornDate = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (!col.CompareTag(father))
            return;
        var manager = col.GetComponent<EquipmentManager>();
        manager.Damaged(this);
        DestroyBullet();
    }

    private void Update() {
        if (Time.time >= _bornDate + 1) {
            DestroyBullet();
        }
    }

    public void FireUp(Vector2 velocity, Vector3 damage, Transform origin) {
        _bulletTransform.position = origin.position;
        _bulletTransform.rotation = origin.rotation;
        _rigidbody2D.velocity = velocity;
        lifeDamage = damage.x;
        shieldDamage = damage.y;
        ignoreShield = damage.z == 1f;
    }

    private void DestroyBullet() {
        parent.bullets.Add(this);
        _rigidbody2D.velocity = new Vector2(0f, 0f);
        gameObject.SetActive(false);
    }
}
