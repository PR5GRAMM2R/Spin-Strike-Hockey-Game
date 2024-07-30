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
            currentPos = GetMouseWorldPos() + offset;   // 마우스로 끌어오는 좌표를 적용

            currentPos.x = Mathf.Clamp(currentPos.x, xMin, xMax);       // 플레이어가 자신의 영역을 벗어나지 않게 함
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
        mousePos.z = mainCamera.WorldToScreenPoint(transform.position).z;   // 화면 상의 마우스 좌표를 월드좌표계로 변경
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
