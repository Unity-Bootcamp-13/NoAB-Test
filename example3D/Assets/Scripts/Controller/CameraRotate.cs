using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed = 5.0f; // ȸ�� ���ǵ� (�ΰ�����)

    private Vector3 startMousePosition; // ��ġ ���� ��ġ	

    private bool isDragging = false;

    public Transform playerTransform;


    float yaw = 0;
    float pitch = 0;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ȭ�� ���� ����
        {
            startMousePosition = Input.mousePosition; // ���� ��ġ ���
            isDragging = true; // �巡�� ����
        }

        if (Input.GetMouseButtonUp(0)) // ȭ�鿡�� �� ����
        {
            isDragging = false; // �巡�� ��
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - startMousePosition; // ���� ��ġ���� ȭ�� ���� ���� ��ġ �� ��ŭ�� �̵� ����
            startMousePosition = Input.mousePosition; // ���� �����ӿ����� ���� ��ġ�� ���� ��ġ�� �� ����

            yaw += delta.x * rotateSpeed * Time.deltaTime; // y�� ���� ȸ�� ���� (�¿�)
            pitch += delta.y * rotateSpeed *  Time.deltaTime; // x�� ���� ȸ�� ���� (����)

            pitch = Mathf.Clamp(pitch, -45, 45);
            
            playerTransform.eulerAngles = new Vector3 (0, yaw, 0); // �÷��̾ ���� y�� ���� ȸ�� (ī�޶� �ڽ��̶� ���� ���ư�)
            this.transform.localEulerAngles = new Vector3 (-pitch, 0, 0); // ī�޶� ���� x�� ���� ȸ��
        }
    }
}
