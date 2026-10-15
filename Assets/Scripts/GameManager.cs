using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text finalScoreText;
    [SerializeField] private Text bestScoreText;

    private float survivalSeconds;
    private int displayedScore;
    private bool playing;

    public bool IsPlaying => playing;
    public float ObstacleSpeed => GameRules.ObstacleSpeed(survivalSeconds);
    public float MinimumSpawnInterval => GameRules.MinimumSpawnInterval(survivalSeconds);
    public float MaximumSpawnInterval => GameRules.MaximumSpawnInterval(survivalSeconds);

    private void Start()
    {
        survivalSeconds = 0f;
        displayedScore = 0;
        playing = true;
        gameOverPanel.SetActive(false);
        scoreText.text = "SCORE  0";
    }

    private void Update()
    {
        if (!playing) return;

        survivalSeconds += Time.deltaTime;
        int score = GameRules.Score(survivalSeconds);
        if (score == displayedScore) return;
        displayedScore = score;
        scoreText.text = "SCORE  " + score;
    }

    public void GameOver()
    {
        if (!playing) return;

        playing = false;
        int score = GameRules.Score(survivalSeconds);
        int best = Mathf.Max(score, PlayerPrefs.GetInt(GameRules.BestScoreKey, 0));
        PlayerPrefs.SetInt(GameRules.BestScoreKey, best);
        PlayerPrefs.Save();

        finalScoreText.text = "Score: " + score;
        bestScoreText.text = "Best: " + best;
        gameOverPanel.SetActive(true);
    }

    public void Restart() => SceneManager.LoadScene("Gameplay");

    public void OpenMainMenu() => SceneManager.LoadScene("MainMenu");
}
