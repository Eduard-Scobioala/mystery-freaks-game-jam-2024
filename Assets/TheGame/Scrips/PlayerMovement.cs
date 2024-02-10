using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Camera cam;

    private Vector2 movement;
    private Vector2 mousePosition;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveSpeed * Time.fixedDeltaTime * movement);

        Vector2 lookDirection = mousePosition - playerRb.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        playerRb.rotation = lookAngle;
    }
}
