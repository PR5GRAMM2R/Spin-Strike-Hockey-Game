using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public bool isMouseDown;
    public Camera mainCamera;

    private Vector3 offset;

    private Vector3 currentPos;

    public float xMin = -2.4f;
    public float xMax = 2.4f;
    public float yMin = 0.6f;
    public float yMax = 4.4f;

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
}
