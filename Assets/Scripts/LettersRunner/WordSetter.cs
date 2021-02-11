using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordSetter : MonoBehaviour
{
    [SerializeField] private GameObject _inputPanel = null;
    [SerializeField] private TMP_InputField _inputField = null;
    [SerializeField] private CellRoad _road = null;
    [SerializeField] private Bot _bot = null;
    [SerializeField] private Player _player = null;
    [SerializeField] private Player _botPlayer = null;

    private bool _playerRound = false;
    private bool _finished = false;

    public void SetWord(Player player)
    {
        SetWord(player, _inputField.text);
    }

    public void SetWord(Player player, string word)
    {
        _road.SetWord(word, player);
    }

    public void Finishing(Cell cell)
    {
        _finished = true;
        if (_playerRound)
        {
            _player.SetWin();
            _botPlayer.SetDefeat();
        }
        else
        {
            _player.SetDefeat();
            _botPlayer.SetWin();
        }
    }

    public void Next()
    {
        if (_finished) return;
        _playerRound = !_playerRound;
        if (_playerRound)
            StartCoroutine(Utils.DelayedCall(1f, () => _inputPanel.SetActive(true)));
        else
            _bot.Begin();
    }

    private void Start()
    {
        _road.OnEndRunning += Next;
        Next();
    }
}
