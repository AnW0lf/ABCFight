using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint = null;
    [SerializeField] private Color _letterColor = Color.green;
    private Animator _animator = null;
    private NavMeshAgent _agent = null;

    public Color LetterColor => _letterColor;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Offset", Random.Range(0f, 1f));
    }

    private void Update()
    {
        if (_targetPoint != null)
            _agent.SetDestination(_targetPoint.position);

        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }

    public void SetWin() => _animator.SetBool("Win", true);
    public void SetDefeat() => _animator.SetBool("Defeat", true);
}
