using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPuck : MonoBehaviour
{
    public PhysicsMaterial2D bouncy;

    public float bouncyRed = 5.0f;
    public float bouncyGreen = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
    }
}
