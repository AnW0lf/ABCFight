using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private bool _freezeX = true;

    private float _startX = 0f;

    private void Start()
    {
        _startX = transform.position.x;
    }

    private void Update()
    {
        if (_freezeX)
        {
            Vector3 position = transform.position;
            position.x = _startX;
            transform.position = position;
        }
    }

    private void FixedUpdate()
    {
        if (_freezeX)
        {
            Vector3 position = transform.position;
            position.x = _startX;
            transform.position = position;
        }
    }

    private void LateUpdate()
    {
        if (_freezeX)
        {
            Vector3 position = transform.position;
            position.x = _startX;
            transform.position = position;
        }
    }
}
