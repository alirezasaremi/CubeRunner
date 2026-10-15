using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public sealed class PlayerJump : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Collider groundCollider;
    [SerializeField] private float jumpSpeed = 8.5f;

    private Rigidbody body;
    private bool jumpQueued;

    private void Awake() => body = GetComponent<Rigidbody>();

    private void Update()
    {
        if (!gameManager.IsPlaying) return;

        bool spacePressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        bool touched = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;
        if (spacePressed || touched) jumpQueued = true;
    }

    private void FixedUpdate()
    {
        if (!jumpQueued) return;
        jumpQueued = false;
        if (!gameManager.IsPlaying || !IsGrounded()) return;

        Vector3 velocity = body.linearVelocity;
        velocity.y = jumpSpeed;
        body.linearVelocity = velocity;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.02f, Vector3.down,
            out RaycastHit hit, 0.62f, Physics.DefaultRaycastLayers,
            QueryTriggerInteraction.Ignore) && hit.collider == groundCollider;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<ObstacleMovement>() != null)
            gameManager.GameOver();
    }
}
