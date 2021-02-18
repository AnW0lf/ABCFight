using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Door[] _doors = null;

    private Navigator _target = null;

    private void Start()
    {
        foreach (var door in _doors) door.OnEnterDoor += EnterDoor;
    }

    private void EnterDoor(Door door, Navigator navigator)
    {
        _target = navigator;
        foreach (var d in _doors) d.Questioned = true;
        _target.QuestController.OnSubmit += Submit;
        _target.QuestController.Begin();
    }

    private void Submit(string word)
    {
        OpenDoors(word.Length, _target);
        _target.QuestController.OnSubmit -= Submit;
    }

    private void OpenDoors(int count, Navigator navigator)
    {
        print("Open doors");
        foreach (var door in _doors) Destroy(door.gameObject, 0.1f);
        navigator.InstantiateMinions(count);
    }
}
