using UnityEngine;

public class EnemyIdle : StateMachineBehaviour
{
    private float _timer;

    // // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0.0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_timer < animator.GetFloat("idlePeriod"))
        {
            _timer += Time.deltaTime;
        }
        else
        {
            animator.SetBool("isPatrolling", true);
        }
    }
}
