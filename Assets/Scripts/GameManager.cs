using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Player player;
    public Player ordi;
    public TextMeshProUGUI PlayerScoreText;
    public TextMeshProUGUI OrdiScoreText;
    public int _scoreplayer;
    public int _scoreordi;

    private const int MaxScore = 3; // Score maximum pour finir le jeu

    public ScreenShake screenShake;  // Référence au script ScreenShake
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.3f;

    public void PlayerScores()
    {
        _scoreplayer++;
        PlayerScoreText.text = _scoreplayer.ToString();
        CheckGameOver();
        if (_scoreplayer < MaxScore)
        {
            ResetGame();
        }
        StartCoroutine(screenShake.Shake(shakeDuration, shakeMagnitude));
    }

    public void OrdiScores()
    {
        _scoreordi++;
        OrdiScoreText.text = _scoreordi.ToString();
        CheckGameOver();
        if (_scoreordi < MaxScore)
        {
            ResetGame();
        }
        StartCoroutine(screenShake.Shake(shakeDuration, shakeMagnitude));
    }

    private void ResetGame()
    {
        player.ResetPosition();
        ordi.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    private void CheckGameOver()
    {
        if (_scoreplayer >= MaxScore || _scoreordi >= MaxScore)
        {
            Debug.Log("Game over reached. Returning to menu.");
            ReturnToMenu();
        }
    }

    private void ReturnToMenu()
    {
        Debug.Log("Loading menu scene...");
        // Load the menu scene. Replace "MenuScene" with the actual name of your menu scene.
        SceneManager.LoadScene("Menu");
    }
}
