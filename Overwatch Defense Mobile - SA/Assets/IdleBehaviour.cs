using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IdleBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ���� ȭ��ǥ Ű ������ LeftAttack Ʈ���� �߻�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("LeftAttack");
        }

        // ������ ȭ��ǥ Ű ������ LeftAttack Ʈ���� �߻�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("RightAttack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
