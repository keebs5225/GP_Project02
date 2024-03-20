using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float rotationSpeed = 5f;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public GameObject weapon;
    [SerializeField] public Transform firePoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public int maxHealth = 100;

    private Rigidbody rb;
    private int PlayerHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerHealth = maxHealth;
    }

    private void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);

        // Rotation
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.velocity = firePoint.forward * projectileSpeed;
    }

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;
        if (PlayerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement death logic here, such as respawning or game over
    }
}
