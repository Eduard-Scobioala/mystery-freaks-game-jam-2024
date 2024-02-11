using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Range(200f, 1000f)]
    [SerializeField] private float speed = 1000f;
    [Range(1f, 10f)]
    [SerializeField] private float lifetime = 3f;
    [Range(1f, 10f)]
    [SerializeField] private float damageAmount = 2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();

            if (enemyHealth != null)
            {
                AudioManager.Instance.PlaySFX("Hit");
                enemyHealth.health -= damageAmount;
            }
            else
            {
                Debug.LogWarning("Enemy is missing Health component.");
            }
        }
            
        Destroy(gameObject);
    }
}
