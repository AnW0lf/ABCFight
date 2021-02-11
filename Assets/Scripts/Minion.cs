using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 1f;
    [SerializeField] private float _horizontalSpeed = 1f;
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

    private float _xCoord = 0f;
    public float XCoord
    {
        get => _xCoord;
        set => _xCoord = Mathf.Clamp(value, -(_wayCount / 2) * 1.5f, (_wayCount / 2) * 1.5f);
    }

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
                _animator.SetFloat("Speed", _forwardSpeed);
                transform.position += transform.forward * _forwardSpeed * Time.deltaTime;

                Vector3 position = transform.position;
                if (Mathf.Abs(position.x - XCoord) < _horizontalSpeed * Time.deltaTime)
                    position.x = XCoord;
                else
                    position.x += Mathf.Sign(XCoord - position.x) * _horizontalSpeed * Time.deltaTime;

                transform.position = position;
                break;
            case State.FIGHT:
                print("Fight");
                break;
            default:
                break;
        }
    }
}
