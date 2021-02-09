using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private int _wayCount = 3;
    [SerializeField] private Animator _animator = null;

    private int _wayNumber = 2;
    public int WayNumber
    {
        get => _wayNumber;
        set
        {
            _wayNumber = Mathf.Clamp(value, 1, _wayCount);
        }
    }

    private float XCoord => (_wayNumber - 2) * 1.5f;

    public Transform Team { get; set; } = null;
    enum State { STAY, MOVE, FIGHT }
    private State _state = State.STAY;

    public void Stay()
    {
        _state = State.STAY;
    }

    public void Move()
    {
        _state = State.MOVE;
    }

    public void Fight()
    {
        _state = State.FIGHT;
    }

    private void Start()
    {
        Move();
    }

    private void Update()
    {
        switch (_state)
        {
            case State.STAY:
                print("Stay");
                break;
            case State.MOVE:
                _animator.SetFloat("Speed", _speed);
                transform.position += transform.forward * _speed * Time.deltaTime;
                Vector3 position = transform.position;
                position.x = XCoord;
                transform.position = Vector3.Lerp(transform.position, position, 0.05f);
                break;
            case State.FIGHT:
                print("Fight");
                break;
            default:
                break;
        }
    }
}
