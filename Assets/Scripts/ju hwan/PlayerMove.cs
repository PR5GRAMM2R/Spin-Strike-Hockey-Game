using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isMouseDown;
    public Camera mainCamera;

    private Vector3 offset;

    private Vector3 currentPos;

    public GameObject leftWall;
    public GameObject bottomWall_1;
    public GameObject bottomWall_2;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;

        float r = GetComponent<CircleCollider2D>().bounds.size.x / 2;

        xMin = bottomWall_1.GetComponent<BoxCollider2D>().bounds.center.x - bottomWall_1.GetComponent<BoxCollider2D>().size.x / 2 + r;
        xMax = bottomWall_2.GetComponent<BoxCollider2D>().bounds.center.x + bottomWall_2.GetComponent<BoxCollider2D>().size.x / 2 - r;
        yMin = leftWall.GetComponent<BoxCollider2D>().bounds.center.y - leftWall.GetComponent<BoxCollider2D>().size.x / 2 + r;
        yMax = leftWall.GetComponent<BoxCollider2D>().bounds.center.y + leftWall.GetComponent<BoxCollider2D>().size.x / 2 - r;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            currentPos = GetMouseWorldPos() + offset;

            currentPos.x = Mathf.Clamp(currentPos.x, xMin, xMax);
            currentPos.y = Mathf.Clamp(currentPos.y, yMin, yMax);

            transform.position = currentPos;
        }
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

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Boundary"))
        {
            isHitWalls = true;
        }
    }*/
}
