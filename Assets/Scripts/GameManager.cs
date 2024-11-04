using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float gameDuration = 60f; // Durée du timer en secondes
    private float timeRemaining;
    public TMP_Text timerText;
    public TMP_Text scoreText;

    private int score = 0;
    private bool isGameActive = true;

    void Start()
    {
        timeRemaining = gameDuration;
        UpdateScoreText();
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

    private void EndGame()
    {
        isGameActive = false;
        timerText.text = "Time: 0";
        // Affiche le score final
        Debug.Log("Game Over! Final Score: " + score);
        // Vous pouvez ajouter ici une UI de fin de jeu pour montrer le score final
    }
}
