using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed = 5.0f; // 회전 스피드 (민감도용)

    private Vector3 startMousePosition; // 터치 시작 위치	

    private bool isDragging = false;

    public Transform playerTransform;


    float yaw = 0;
    float pitch = 0;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 화면 누른 순간
        {
            startMousePosition = Input.mousePosition; // 누른 위치 기억
            isDragging = true; // 드래그 시작
        }

        if (Input.GetMouseButtonUp(0)) // 화면에서 손 떼면
        {
            isDragging = false; // 드래그 끝
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - startMousePosition; // 현재 위치에서 화면 누른 순간 위치 뺀 만큼이 이동 벡터
            startMousePosition = Input.mousePosition; // 다음 프레임에서는 현재 위치가 시작 위치가 될 거임

            yaw += delta.x * rotateSpeed * Time.deltaTime; // y축 기준 회전 정도 (좌우)
            pitch += delta.y * rotateSpeed *  Time.deltaTime; // x축 기준 회전 정도 (상하)

            pitch = Mathf.Clamp(pitch, -45, 45);
            
            playerTransform.eulerAngles = new Vector3 (0, yaw, 0); // 플레이어를 월드 y축 기준 회전 (카메라도 자식이라서 같이 돌아감)
            this.transform.localEulerAngles = new Vector3 (-pitch, 0, 0); // 카메라만 로컬 x축 기준 회전
        }
    }
}
