using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isMouseDown;
    public Camera mainCamera;

    private Vector3 offset;

    private Vector3 currentPos;
    public bool isHitWalls = false;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            if (!isHitWalls)
            {
                currentPos = GetMouseWorldPos() + offset;
            }

            isHitWalls = false;
        }

        transform.position = currentPos;
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Boundary"))
        {
            isHitWalls = true;
        }
    }
}
