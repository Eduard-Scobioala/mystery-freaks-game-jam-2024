using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private PlayerHealthController healthController;
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private string _newGameLevel;
    [SerializeField] private string _menuLevel;

    private void FixedUpdate()
    {
        if (!healthController.isPlayerAlive)
        {
            gameOverPopup.SetActive(true);
            ScoreTextSetup();
        }
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void OnExitButtonPressed()
    {
        SceneManager.LoadScene(_menuLevel);
    }

    private void ScoreTextSetup()
    {
        scoreText.SetText(scoreController.scoreValue.ToString());

        int highScore = GetHighScore(scoreController.scoreValue);
        highScoreText.SetText(highScore.ToString());
    }

    private int GetHighScore(int score)
    {
        // Check if the HighScore value doesn't exist (first time setup)
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }

        return highScore;
    }
}
