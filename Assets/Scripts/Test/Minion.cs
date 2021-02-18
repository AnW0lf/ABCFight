using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private NavMeshAgent _agent = null;

    private void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }
}
