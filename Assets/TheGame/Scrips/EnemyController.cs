using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 3;
    public float rotateSpeed = 0.002f;

    [Range(0f, 10f)]
    [SerializeField] private float damageAmount = 2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * -speed;
    }

    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 180f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController enemyHealth = collision.gameObject.GetComponent<PlayerHealthController>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamange(damageAmount);
            }
            else
            {
                Debug.LogWarning("Enemy is missing Health component.");
            }
        }
    }
}
