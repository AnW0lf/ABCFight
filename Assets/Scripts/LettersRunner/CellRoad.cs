using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellRoad : MonoBehaviour
{
    [SerializeField] private Transform _targetPoints = null;
    [SerializeField] private Cell[] _cells = null;

    private int _emptyCellIndex = 0;

    public UnityAction OnEndRunning { get; set; } = null;

    private void Start()
    {
        foreach (var cell in _cells)
            cell.OnActivateCell += EndRunning;
    }

    private void EndRunning(Cell cell)
    {
        if (cell == _cells[_emptyCellIndex - 1])
            OnEndRunning?.Invoke();

    }

    public void SetWord(string word, Player player)
    {
        word = word.ToUpper();
        foreach(var letter in word)
        {
            if (IsFull) break;
            _cells[_emptyCellIndex].Letter = letter.ToString();
            _cells[_emptyCellIndex].LetterColor = player.LetterColor;
            _emptyCellIndex++;
        }

        _targetPoints.position = Vector3.forward * (_emptyCellIndex) * _cells[_emptyCellIndex - 1].transform.lossyScale.z +
            Vector3.up * _cells[_emptyCellIndex - 1].transform.lossyScale.y / 2f;
    }

    public bool IsFull => _emptyCellIndex >= _cells.Length;
}
