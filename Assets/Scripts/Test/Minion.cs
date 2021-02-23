using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Team _team = Team.Team1;

    public Team Team
    {
        get => _team;
        set => _team = value;
    }
    public bool Fight { get; set; } = false;

    public float Health { get; set; } = 10f;
    private float _damage = 3f;
    private Minion _enemy = null;

    private void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);

        if (Fight)
        {
            if (_enemy == null)
            {
                var enemies = FindObjectsOfType<Minion>().Where((m) => m.Team != Team);
                float distance = float.MaxValue;
                foreach (var enemy in enemies)
                {
                    float newDistance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        _enemy = enemy;
                    }
                }
            }

            if (_enemy != null)
            {
                _animator.SetBool("Win", false);
                if (Vector3.Distance(transform.position, _enemy.transform.position) < 3f)
                {
                    _animator.SetBool("Fight", true);
                    _enemy.Health -= _damage * Time.deltaTime;
                }
                else
                    _animator.SetBool("Fight", false);
                _agent.SetDestination(_enemy.transform.position);
            }
            else
            {
                _animator.SetBool("Fight", false);
                _animator.SetBool("Win", true);
                _agent.SetDestination(transform.position);
            }
        }

        if (Health <= 0f) Destroy(gameObject);
    }
}

public enum Team { Team1, Team2, Team3, Team4 }
