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
            Vector3 forward = Camera.main.transform.forward; // 플레이어 앞쪽의 기준은 메인 카메라가 바라보는 방향
            Vector3 right = Camera.main.transform.right; // 플레이어 오른쪽의 기준은 메인 카메라의 오른쪽 방향

            // 카메라가 바라보는 방향이 상하로 틀어져있을 수 있으니 y값은 0으로 만들었음
            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            Vector3 moveDir = (right * inputHorizontal + forward * inputVertical); // 플레이어가 움직일 방향

            rigidbody.MovePosition(transform.position + moveDir * 4f * Time.deltaTime);

        }
    }
}
