using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuckControl : MonoBehaviour
{
    private Rigidbody2D puckRb;

    private float pastTime;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        puckRb = GetComponent<Rigidbody2D>();

        pastTime = Time.time;
        currentTime = Time.time;
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
}
