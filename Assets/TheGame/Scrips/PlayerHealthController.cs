using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;
    public bool isPlayerAlive = true;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            isPlayerAlive = false;
            Destroy(gameObject);
        }
    }

    public void TakeDamange(float damange)
    {
        AudioManager.Instance.PlaySFX("TakeDmg");
        currentHealth -= damange;
        healthBar.SetValue(currentHealth);
    }
}
