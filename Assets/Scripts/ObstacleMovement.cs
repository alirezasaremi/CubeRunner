using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public sealed class ObstacleMovement : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody body;
    private float removalX;

    public void Initialize(GameManager manager, float leftEdge)
    {
        gameManager = manager;
        removalX = leftEdge;
    }

    private void Awake() => body = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        if (gameManager == null || !gameManager.IsPlaying) return;

        body.MovePosition(body.position + Vector3.left * (gameManager.ObstacleSpeed * Time.fixedDeltaTime));
        if (body.position.x < removalX) Destroy(gameObject);
    }
}
