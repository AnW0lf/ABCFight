using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BotMoveController : MonoBehaviour
{
    [SerializeField] private Transform _navigator = null;
    [SerializeField] private QuestController _questController = null;
    [SerializeField] private float[] _xPositions = null;

    private void Start()
    {
        _questController.OnSubmit += SetXPosition;
        SetXPosition("");
    }

    private void SetXPosition(string word)
    {
        Vector3 position = _navigator.position;
        position.x = _xPositions[Random.Range(0, _xPositions.Length)];
        _navigator.position = position;
    }
}
