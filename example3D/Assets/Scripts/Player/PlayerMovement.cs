using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float inputHorizontal, inputVertical;

    public void OnStickChanged(Vector2 stickPos)
    {
        inputHorizontal = stickPos.x;
        inputVertical = stickPos.y;
    }

    void Update()
    {

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (rigidbody)
        {
            Vector3 forward = Camera.main.transform.forward; // �÷��̾� ������ ������ ���� ī�޶� �ٶ󺸴� ����
            Vector3 right = Camera.main.transform.right; // �÷��̾� �������� ������ ���� ī�޶��� ������ ����

            // ī�޶� �ٶ󺸴� ������ ���Ϸ� Ʋ�������� �� ������ y���� 0���� �������
            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            Vector3 moveDir = (right * inputHorizontal + forward * inputVertical); // �÷��̾ ������ ����

            rigidbody.MovePosition(transform.position + moveDir * 4f * Time.deltaTime);

        }
    }
}
