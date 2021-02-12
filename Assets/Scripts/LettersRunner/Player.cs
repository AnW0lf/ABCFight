using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Color _letterColor = Color.green;
    private Animator _animator = null;
    private NavMeshAgent _agent = null;

    public Transform TargetPoint { get; set; } = null;
    public ManChain ManChain { get; set; } = null;

    public Color LetterColor => _letterColor;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Offset", Random.Range(0f, 1f));
    }

    private void Update()
    {
        Vector3 destination = transform.position;
        if (ManChain != null && ManChain.Contains(this))
            destination = ManChain.GetDestination(this);
        else if (TargetPoint != null)
            destination = TargetPoint.position;

        _agent.SetDestination(destination);
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }

    public void SetWin() => _animator.SetBool("Win", true);
    public void SetDefeat() => _animator.SetBool("Defeat", true);
}
