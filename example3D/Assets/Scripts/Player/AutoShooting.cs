using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider.CompareTag("Enemy"))
            { 
                Debug.Log("���鿡 �� ����");
                Debug.Log("�Ѿ� �ڵ� �߻�");       
            }

            else
            {
                Debug.Log("���� ����");
            }
        }
    }
}
