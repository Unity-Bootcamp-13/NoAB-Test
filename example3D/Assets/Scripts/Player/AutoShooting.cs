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
                Debug.Log("정면에 적 감지");
                Debug.Log("총알 자동 발사");       
            }

            else
            {
                Debug.Log("조준 끝남");
            }
        }
    }
}
