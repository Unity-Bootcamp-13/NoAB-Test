using System;
using UnityEngine;

public class TouchPad : MonoBehaviour
{
    private RectTransform _touchPad; // 터치패드 위치
    private Vector3 _startPos; // 터치패드 좌표
    public float _dragRadius = 120.0f; // 방향 컨트롤러 움직이는 최대 반지름
    public PlayerMovement _player; // 플레이어 위치 바꿔주기 위함
    private bool _buttonPressed = false; // 버튼 눌림 여부

    private void Start()
    {
        _touchPad = GetComponent<RectTransform>();

        //터치 패드 좌표 (기준 값)
        _startPos = _touchPad.position;
    }

    public void ButtonDown()
    {
        _buttonPressed = true;
    }
    public void ButtonUp()
    {
        _buttonPressed = false;
    }

    private void FixedUpdate()
    {
        //크로스 플랫폼 : 플랫폼 따라 코드 나누기

        //PC나 에디터 상에서 실행하는 경우에 대한 설정
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE
        HandleTouchInput(Input.mousePosition);
#else
             HandleTouchInput(); 
#endif
    }

    private void HandleTouchInput(Vector3 mousePosition)
    {
        if (_buttonPressed) // 터치패드 버튼 눌려있다면
        {
            Vector3 diff = mousePosition - _startPos;

            if (diff.sqrMagnitude > _dragRadius * _dragRadius)
            {
                diff.Normalize();

                _touchPad.position = _startPos + diff * _dragRadius;
            }
            else
            {
                _touchPad.position = mousePosition;
            }

            Vector3 distance = _touchPad.position - _startPos;

            Vector2 normalDiff = new Vector3(distance.x / _dragRadius, distance.y / _dragRadius, distance.z / _dragRadius);

            if (_player != null)
            {
                _player.OnStickChanged(normalDiff);
            }
        }
        else // 터치패드 버튼 떼면
        {
            _touchPad.position = _startPos; // 터치패드 버튼 위치 원래자리로
            _player.OnStickChanged(Vector2.zero); // 플레이어 정지시킴

        }
    }

    private void HandleTouchInput()
    {
        Debug.Log("모바일 빌드");
    }

    private void ThisIsTest()
    {
        string HaHaHA = "Test";
    }
}