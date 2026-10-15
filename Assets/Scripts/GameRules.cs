using UnityEngine;

public static class GameRules
{
    public const string BestScoreKey = "CubeRunner.BestScore";

    public static int Score(float survivalSeconds) => Mathf.FloorToInt(Mathf.Max(0f, survivalSeconds));

    public static float ObstacleSpeed(float survivalSeconds) =>
        Mathf.Min(11f, 7f + Mathf.Max(0f, survivalSeconds) * 0.035f);

    public static float MinimumSpawnInterval(float survivalSeconds) =>
        Mathf.Max(1.15f, 1.65f - Mathf.Max(0f, survivalSeconds) * 0.004f);

    public static float MaximumSpawnInterval(float survivalSeconds) =>
        MinimumSpawnInterval(survivalSeconds) + 0.45f;
}
