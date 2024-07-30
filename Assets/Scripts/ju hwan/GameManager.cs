using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SearchService;

public class GameManager1 : MonoBehaviour
{
    public float time = 150.0f;

    private float pastTime;
    private float currentTIme;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;
    public TextMeshProUGUI scoreStackedText;

    public GameObject puck;
    public GameObject boundary;

    public GameObject topWall;
    public GameObject bottomWall;

    private float playerGoalYPos;
    private float opponentGoalYPos;

    public int playerScore = 0;
    public int opponentScore = 0;

    public int scoreStacked = 0;

    // Start is called before the first frame update
    void Awake()
    {
        pastTime = Time.time;
        currentTIme = Time.time;

        puck.transform.position = boundary.transform.position;

        playerGoalYPos = topWall.transform.position.y;
        opponentGoalYPos = bottomWall.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentTIme = Time.time;

        if(currentTIme - pastTime > 0.1f)
        {
            time -= 0.1f;
            pastTime = currentTIme;
            scoreText.text = ((int)(time / 0.1f) / 10.0f).ToString();
        }

        if(puck.transform.position.y > playerGoalYPos)
        {
            playerScore += scoreStacked;
            scoreStacked = 0;
            scoreStackedText.text = scoreStacked.ToString();
            playerScoreText.text = playerScore.ToString();
        }

        if (puck.transform.position.y < opponentGoalYPos)
        {
            opponentScore += scoreStacked;
            scoreStacked = 0;
            scoreStackedText.text = scoreStacked.ToString();
            opponentScoreText.text = opponentScore.ToString();
        }

        /*if(time <= 0)
        {
            
        }*/
    }
}
