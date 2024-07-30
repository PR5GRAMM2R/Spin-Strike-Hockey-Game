using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public float time = 150.0f;

    private float pastTime;
    private float currentTIme;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        pastTime = Time.time;
        currentTIme = Time.time;
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
    }
}
