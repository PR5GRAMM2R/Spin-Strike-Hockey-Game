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

    public GameObject player;
    public GameObject opponent;
    public GameObject boundary;

    public GameObject topWall;
    public GameObject bottomWall;

    private float playerGoalYPos;
    private float opponentGoalYPos;

    public int playerScore = 0;
    public int opponentScore = 0;

    public int scoreStacked = 0;

    public GameObject puckPrefab;

    private GameObject puck;

    // Start is called before the first frame update
    void Awake()
    {
        pastTime = Time.time;
        currentTIme = Time.time;

        puck = Instantiate(puckPrefab, boundary.transform.position, new Quaternion(0, 0, 0, 0));

        playerGoalYPos = topWall.transform.position.y;
        opponentGoalYPos = bottomWall.transform.position.y;

        player.transform.position = boundary.transform.position + new Vector3(0, opponentGoalYPos, 0) / 2;
        opponent.transform.position = boundary.transform.position + new Vector3(0, playerGoalYPos, 0) / 2;
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
            Destroy(puck);
            puck = Instantiate(puckPrefab, boundary.transform.position, new Quaternion(0, 0, 0, 0));
            player.transform.position = boundary.transform.position + new Vector3(0, opponentGoalYPos, 0) / 2;
            opponent.transform.position = boundary.transform.position + new Vector3(0, playerGoalYPos, 0) / 2;
        }

        if (puck.transform.position.y < opponentGoalYPos)
        {
            opponentScore += scoreStacked;
            scoreStacked = 0;
            scoreStackedText.text = scoreStacked.ToString();
            opponentScoreText.text = opponentScore.ToString();
            Destroy(puck);
            puck = Instantiate(puckPrefab, boundary.transform.position, new Quaternion(0, 0, 0, 0));
            player.transform.position = boundary.transform.position + new Vector3(0, opponentGoalYPos, 0) / 2;
            opponent.transform.position = boundary.transform.position + new Vector3(0, playerGoalYPos, 0) / 2;
        }

        /*if(time <= 0)
        {
            
        }*/
    }
}
