using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private float _maxDistanse = 2f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float direction = transform.localScale.x > 0f ? -1f : 1f;
        //_rigidbody2D.velocity = new Vector2(_speed * direction, 0f);
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
        Destroy(gameObject, _maxDistanse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
