using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float gameDuration = 60f; // Durée du timer en secondes
    private float timeRemaining;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    public TMP_Text GameOverText;
    public GameObject gameOverPanel;


    private int score = 0;
    private int bestScore = 0;
    private bool isGameActive = true;

    void Start()
    {
        gameOverPanel.SetActive(false);
        timeRemaining = gameDuration;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreText();
        UpdateBestScoreText();
    }

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (isGameActive)
        {
            // Compte à rebours
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();

            // Vérifie si le temps est écoulé
            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateBestScoreText()
    {
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    private void EndGame()
    {
        isGameActive = false;
        timerText.text = "Time: 0";
        // Affiche le score final
        Debug.Log("Game Over! Final Score: " + score);
        gameOverPanel.SetActive(true);
        GameOverText.text = "Final Score: " + score;
        Time.timeScale = 0;

        // Met à jour le meilleur score si nécessaire
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            UpdateBestScoreText();
        }
    }
    public static void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
