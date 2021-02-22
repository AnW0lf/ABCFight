using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Navigator _player = null;
    [SerializeField] private MoveController _playerMove = null;
    [SerializeField] private Navigator _bot = null;
    [SerializeField] private BotMoveController _botMove = null;

    private bool _fight = false;

    private void Update()
    {
        if (!_fight)
        {
            if (Mathf.Abs(_player.transform.position.z - _bot.transform.position.z) < 3f)
            {
                _fight = true;

                _player.BeginFight();
                _bot.BeginFight();

                _player.enabled = false;
                _bot.enabled = false;

                Destroy(_playerMove);
                Destroy(_botMove);
            }
        }
    }
}
