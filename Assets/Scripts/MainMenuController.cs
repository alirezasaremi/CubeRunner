using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class MainMenuController : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;

    private void Start()
    {
        bestScoreText.text = "BEST  " + PlayerPrefs.GetInt(GameRules.BestScoreKey, 0);
    }

    public void Play() => SceneManager.LoadScene("Gameplay");
}
