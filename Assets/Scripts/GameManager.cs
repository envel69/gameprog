using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Ball ball;

    public Player player;
    public Player ordi;

    public TextMeshProUGUI PlayerScoreText;
    public TextMeshProUGUI OrdiScoreText;


    private int _scoreplayer;
    private int _scoreordi;

    public void PlayerScores()
    {
        _scoreplayer++;

        this.PlayerScoreText.text = _scoreplayer.ToString();
        this.player.ResetPosition();
        this.ordi.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();

        
    }

    public void OrdiScores()
    {
        _scoreordi++;

        this.OrdiScoreText.text = _scoreordi.ToString();
        this.player.ResetPosition();
        this.ordi.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

    

}
