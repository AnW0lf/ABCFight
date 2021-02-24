using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Player _player = null;
    [SerializeField] private WordSetter _wordSetter = null;
    [SerializeField] private string[] _words = null;

    public void Begin()
    {
        StartCoroutine(Utils.DelayedCall(4f, () => _wordSetter.SetWord(_player, _words[Random.Range(0, _words.Length)])));
    }
}
