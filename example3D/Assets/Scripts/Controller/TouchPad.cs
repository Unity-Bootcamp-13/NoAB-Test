using System;
using UnityEngine;

public class TouchPad : MonoBehaviour
{
    private RectTransform _touchPad; // ��ġ�е� ��ġ
    private Vector3 _startPos; // ��ġ�е� ��ǥ
    public float _dragRadius = 120.0f; // ���� ��Ʈ�ѷ� �����̴� �ִ� ������
    public PlayerMovement _player; // �÷��̾� ��ġ �ٲ��ֱ� ����
    private bool _buttonPressed = false; // ��ư ���� ����

    private void Start()
    {
        _touchPad = GetComponent<RectTransform>();

        //��ġ �е� ��ǥ (���� ��)
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
        //ũ�ν� �÷��� : �÷��� ���� �ڵ� ������

        //PC�� ������ �󿡼� �����ϴ� ��쿡 ���� ����
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE
        HandleTouchInput(Input.mousePosition);
#else
             HandleTouchInput(); 
#endif
    }

    private void HandleTouchInput(Vector3 mousePosition)
    {
        if (_buttonPressed) // ��ġ�е� ��ư �����ִٸ�
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
        else // ��ġ�е� ��ư ����
        {
            _touchPad.position = _startPos; // ��ġ�е� ��ư ��ġ �����ڸ���
            _player.OnStickChanged(Vector2.zero); // �÷��̾� ������Ŵ

        }
    }

    private void HandleTouchInput()
    {
        Debug.Log("����� ����");
    }

    private void ThisIsTest()
    {
        string HaHaHA = "Test";
    }
}