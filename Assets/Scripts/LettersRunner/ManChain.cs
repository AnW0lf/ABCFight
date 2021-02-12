using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManChain : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint = null;
    [SerializeField] private float _distance = 1f;

    private List<Player> _players = new List<Player>();

    public void AddPlayer(Player player)
    {
        if (!_players.Contains(player))
            _players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        if (_players.Contains(player))
            _players.Remove(player);
    }

    public bool Contains(Player player) => _players.Contains(player);

    public Vector3 GetDestination(Player player)
    {
        if (!_players.Contains(player)) return Vector3.zero;

        int index = _players.IndexOf(player);

        return _targetPoint.position - _targetPoint.forward * index * _distance;
    }
}
