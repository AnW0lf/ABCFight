using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label = null;
    [SerializeField] private TMP_InputField _input = null;
    [SerializeField] private GameObject _window = null;
    [SerializeField] private Image _fade = null;

    public UnityAction<string> OnSubmit { get; set; } = null;

    protected QuestionData _questionData = null;

    public virtual void Begin(QuestionData questionData)
    {
        _questionData = questionData;
        _label.text = _questionData.Question;
        _window.SetActive(true);
        StartCoroutine(Utils.CrossFading(Vector3.zero, Vector3.one, 0.4f, (scale) => _window.transform.localScale = scale, (a, b, c) => Vector3.Lerp(a, b, c)));
        StartCoroutine(Utils.CrossFading(Vector3.forward * 126f, Vector3.zero, 0.4f, (angle) => _window.transform.localEulerAngles = angle, (a, b, c) => Vector3.Lerp(a, b, c)));
        _fade.enabled = true;
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
        _fade.enabled = false;
        OnSubmit?.Invoke(value);
    }
}
