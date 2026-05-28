using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public GameObject loseScreenUI;
    public int Score, HighScore;
    public Text scoreUI, HighScoreUI;
    string HighScoreKey = "HighScore";
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighScore = PlayerPrefs.GetInt(HighScoreKey);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.singleton.PlaySound(0);
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    void PlayerLose()
    {
        AudioManager.singleton.PlaySound(1);
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(HighScoreKey, HighScore);
        }
        
        HighScoreUI.text = " HighScore: " + HighScore.ToString();
        loseScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void AddScore()
    {
        AudioManager.singleton.PlaySound(2);
        Score++;
        scoreUI.text = " Score: " + Score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            PlayerLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            AddScore();
        }
    }
}
