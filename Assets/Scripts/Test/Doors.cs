using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Door[] _doors = null;

    private void Start()
    {
        foreach (var door in _doors) door.OnEnterDoor += EnterDoor;
    }

    private void EnterDoor(Door door, Navigator navigator)
    {
        print($"{navigator.name} enter door {door.name}");
        foreach (var d in _doors) d.Questioned = true;
        StartCoroutine(Utils.DelayedCall(5f, () => OpenDoors(3, navigator)));
    }

    private void OpenDoors(int count, Navigator navigator)
    {
        print("Open doors");
        foreach (var door in _doors) Destroy(door.gameObject, 0.1f);
        navigator.InstantiateMinions(count);
    }
}
