using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private float _smoothness = 0.15f;
    private Transform _camera = null;
    private Vector3 _direction = Vector3.zero;

    private void OnEnable()
    {
        _camera = Camera.main.transform;
        _direction = (_camera.position - transform.position).normalized;
        _direction.y = 0f;
        _direction.Normalize();
    }

    private void Update()
    {
        Vector3 forward = transform.forward;
        forward = Vector3.Lerp(forward, _direction, _smoothness);
        transform.LookAt(transform.position + forward);
    }
}
