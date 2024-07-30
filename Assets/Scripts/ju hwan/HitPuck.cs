using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPuck : MonoBehaviour
{
    private Vector3 pastPos;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        pastPos = transform.position;
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pastPos = currentPos;
        currentPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))        // 퍽과 부딪히면
        {
            Rigidbody2D puckRb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector3 direction = currentPos - pastPos;

            puckRb.AddForce(direction * (1.0f / Time.deltaTime), ForceMode2D.Impulse);  // 퍽을 플레이어 이동방향으로 힘을 가함

            /*Rigidbody2D puckRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D thisRb = gameObject.GetComponent<Rigidbody2D>();

            Vector2 normal = collision.gameObject.transform.position - transform.position;

            //Vector2 normal = collision.contacts[0].normal;

            Vector2 incomingVector = puckRb.velocity;
            Vector2 reflectVector = Vector2.Reflect(incomingVector, normal);

            puckRb.velocity = Vector2.zero;

            puckRb.AddForce(reflectVector, ForceMode2D.Impulse);

            if (Vector2.Dot(thisRb.velocity, normal) > 0)
            {
                puckRb.AddForce(Vector2.Dot(thisRb.velocity.normalized, normal.normalized) * thisRb.velocity * (1.0f / Time.deltaTime), ForceMode2D.Impulse);
            }*/
        }
    }
}
