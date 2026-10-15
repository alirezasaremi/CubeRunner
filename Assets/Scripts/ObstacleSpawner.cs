using UnityEngine;

public sealed class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float spawnX = 11f;
    [SerializeField] private float removalX = -11f;

    private ObstacleMovement obstaclePrefab;
    private float nextSpawnTime;

    private void Awake() => obstaclePrefab = Resources.Load<GameObject>("Obstacle").GetComponent<ObstacleMovement>();

    private void Start()
    {
        Camera camera = Camera.main;
        float visibleHalfWidth = camera.orthographicSize * camera.aspect;
        spawnX = Mathf.Max(spawnX, visibleHalfWidth + 1f);
        removalX = Mathf.Min(removalX, -visibleHalfWidth - 2f);
        ScheduleNextSpawn();
    }

    private void Update()
    {
        if (!gameManager.IsPlaying || Time.time < nextSpawnTime) return;

        ObstacleMovement obstacle = Instantiate(obstaclePrefab,
            new Vector3(spawnX, obstaclePrefab.transform.position.y, 0f), Quaternion.identity);
        obstacle.Initialize(gameManager, removalX);
        ScheduleNextSpawn();
    }

    private void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(
            gameManager.MinimumSpawnInterval, gameManager.MaximumSpawnInterval);
    }
}
