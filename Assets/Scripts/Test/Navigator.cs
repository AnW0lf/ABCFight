using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Navigator : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private bool _active = true;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distanceStep = 1f;
    [SerializeField] private List<NavMeshAgent> _agents = null;
    [Header("Minion")]
    [SerializeField] private GameObject _minionPrefab = null;
    [SerializeField] private QuestController _questController = null;
    [SerializeField] private Team _team = Team.Player;
    [SerializeField] private NotificationsController _notificaions = null;
    [SerializeField] private Material _material = null;

    public QuestController QuestController => _questController;

    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            if (!_active)
            {
                _agents = _agents.Where((agent) => agent != null).ToList();
                foreach (var agent in _agents) agent.SetDestination(agent.transform.position);
            }
        }
    }

    public void AddAgent(NavMeshAgent agent)
    {
        if (!_agents.Contains(agent))
        {
            Minion minion = agent.GetComponent<Minion>();
            minion.Material = _material;
            minion.Team = _team;
            _agents.Add(agent);
        }
    }

    public void RemoveAgent(NavMeshAgent agent)
    {
        if (_agents.Contains(agent))
            _agents.Remove(agent);
    }

    public bool ContainsAgent(NavMeshAgent agent) => _agents.Contains(agent);

    public void BeginFight()
    {
        foreach (var agent in _agents)
        {
            agent.GetComponent<Minion>().Fight = true;
        }
        Camera.main.GetComponent<CameraController>().BeginFight();
    }

    private void Update()
    {
        if (!Active) return;
        _agents = _agents.Where((agent) => agent != null).ToList();

        int j = 0;
        int k = 0;
        for (int i = 0; i < _agents.Count; i++)
        {
            _agents[i].SetDestination(transform.position);
            _agents[i].stoppingDistance = k * _distanceStep;
            j++;
            if (j > k)
            {
                j = 0;
                if (k < 4)
                    k++;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Active) return;
        transform.position += transform.forward * _speed * Time.fixedDeltaTime;
    }

    public void InstantiateMinions(int count)
    {
        for (int i = 0; i < count; i++)
            InstantiateMinion();
        if (_notificaions != null)
            _notificaions.Request($"+{count}");
    }

    public void InstantiateMinion()
    {
        Vector3 position = transform.position;
        int row = 0;
        int count = _agents.Count;
        int i = 1;
        while (count - i >= 0)
        {
            row++;
            count -= i;
            if (i < 4)
                i++;
        }
        position -= transform.forward * row * _distanceStep;

        NavMeshAgent agent = Instantiate(_minionPrefab).GetComponent<NavMeshAgent>();
        agent.transform.position = position;
        agent.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        agent.Warp(position);

        StartCoroutine(Utils.CrossFading(Vector3.zero, Vector3.one, 0.5f, (scale) => agent.transform.localScale = scale, (a, b, c) => Vector3.Lerp(a, b, c)));

        AddAgent(agent);
    }
}
