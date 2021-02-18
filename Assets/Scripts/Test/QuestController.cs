using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input = null;
    [SerializeField] private GameObject _window = null;

    public UnityAction<string> OnSubmit { get; set; } = null;

    public virtual void Begin()
    {
        _window.SetActive(true);
        _input.text = "";
        _input.Select();
    }

    private string ReadValue()
    {
        string value = _input.text.ToLower();
        return value;
    }

    public virtual void Submit()
    {
        string value = ReadValue();
        if (string.IsNullOrEmpty(value)) return;
        _window.SetActive(false);
        OnSubmit?.Invoke(value);
    }
}
