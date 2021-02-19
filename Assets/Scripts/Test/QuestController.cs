using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label = null;
    [SerializeField] private TMP_InputField _input = null;
    [SerializeField] private GameObject _window = null;

    public UnityAction<string> OnSubmit { get; set; } = null;

    protected QuestionData _questionData = null;

    public virtual void Begin(QuestionData questionData)
    {
        _questionData = questionData;
        _label.text = _questionData.Question;
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
        if (string.IsNullOrEmpty(value) ||!_questionData.CheckAnswer(value)) return;
        _window.SetActive(false);
        OnSubmit?.Invoke(value);
    }
}
