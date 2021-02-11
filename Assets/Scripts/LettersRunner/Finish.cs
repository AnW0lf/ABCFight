using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Cell _cell = null;
    [SerializeField] private WordSetter _wordSetter = null;

    private void Start()
    {
        _cell.OnActivateCell = Finishing;
    }

    private void Finishing(Cell cell)
    {
        _wordSetter.Finishing(cell);
    }
}
