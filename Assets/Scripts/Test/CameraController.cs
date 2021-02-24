using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _zoom = 8f;

    private float _startX = 0f;
    private bool _fight = false;
    private Vector3 _endPosition = Vector3.zero;

    private void Start()
    {
        _startX = transform.position.x;
    }

    private void Update()
    {
        if (!_fight)
        {
            Vector3 position = transform.position;
            position.x = _startX;
            transform.position = position;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _endPosition, 0.75f * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (!_fight)
        {
            Vector3 position = transform.position;
            position.x = _startX;
            transform.position = position;
        }
    }

    private void LateUpdate()
    {
        if (!_fight)
        {
            Vector3 position = transform.position;
            position.x = _startX;
            transform.position = position;
        }
    }

    public void BeginFight()
    {
        _fight = true;
        _endPosition = transform.position + transform.forward * _zoom;
    }
}
