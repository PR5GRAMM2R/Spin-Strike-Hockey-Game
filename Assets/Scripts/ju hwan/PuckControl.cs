using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PuckControl : MonoBehaviour
{
    private Rigidbody2D puckRb;

    private float pastTime;
    private float currentTime;

    private TextMeshProUGUI scoreStackedText;
    //public int scoreStacked = 0;

    private GameManager1 gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        puckRb = GetComponent<Rigidbody2D>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager1>();

        pastTime = Time.time;   
        currentTime = Time.time;

        scoreStackedText = GameObject.Find("GameManager").GetComponent<GameManager1>().scoreStackedText;

        gameManagerScript.scoreStacked = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = puckRb.velocity.magnitude;

        currentTime = Time.time;

        if (velocity < 0)
        {
            return;
        }

        if(currentTime - pastTime > 0.1)
        {
            pastTime = currentTime;
            puckRb.velocity *= 0.99f;
        }

        if(velocity > 15)
        {
            puckRb.velocity *= 15 / velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameManagerScript.scoreStacked++;
            scoreStackedText.text = gameManagerScript.scoreStacked.ToString();
        }
    }
}
