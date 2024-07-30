using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPuck : MonoBehaviour
{
    public PhysicsMaterial2D bouncy;

    public float bouncyRed = 2.0f;
    public float bouncyGreen = 0.5f;

    public GameObject puck;

    public float detectLength = 0.3f;
    private float temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = GetComponent<CircleCollider2D>().bounds.size.x / 2 + puck.GetComponent<CircleCollider2D>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerToPuck = puck.transform.position - transform.position;

        if(playerToPuck.magnitude < temp + detectLength)
        {
            Vector2 lookUpDirection = transform.up;
            Vector2 lookRightDirection = transform.right;
            //Debug.Log(lookRightDirection);

            float upDot = Vector2.Dot(playerToPuck, lookUpDirection);
            float rightDot = Vector2.Dot(playerToPuck, lookRightDirection);

            // Green    |   Red
            // Red      |   Green

            if (upDot > 0 && rightDot > 0)
            {
                bouncy.bounciness = bouncyRed;
                //Debug.Log("1");
            }
            else if (upDot > 0 && rightDot <= 0)
            {
                bouncy.bounciness = bouncyGreen;
                //Debug.Log("4");
            }
            else if (upDot <= 0 && rightDot > 0)
            {
                bouncy.bounciness = bouncyGreen;
                //Debug.Log("2");
            }
            else if (upDot <= 0 && rightDot <= 0)
            {
                bouncy.bounciness = bouncyRed;
                //Debug.Log("3");
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            Vector2 lookUpDirection = transform.up;
            Vector2 lookRightDirection = transform.right;
            //Debug.Log(lookDirection);

            Vector2 playerToPuck = collision.transform.position - transform.position;

            float upDot = Vector2.Dot(playerToPuck, lookUpDirection);
            float rightDot = Vector2.Dot(playerToPuck, lookRightDirection);

            // Green    |   Red
            // Red      |   Green

            if (upDot > 0 && rightDot > 0)
            {
                bouncy.bounciness = bouncyRed;
            }
            else if (upDot > 0 && rightDot <= 0)
            {
                bouncy.bounciness = bouncyGreen;
            }
            else if (upDot <= 0 && rightDot > 0)
            {
                bouncy.bounciness = bouncyRed;
            }
            else if (upDot <= 0 && rightDot <= 0)
            {
                bouncy.bounciness = bouncyGreen;
            }
        }
    }*/
}
