using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestion", menuName = "Custom/Question", order = 1)]
public class QuestionData : ScriptableObject
{
    [SerializeField] private string _question = "";
    [Tooltip("Отыеты должны быть написаны нижним регистром")]
    [SerializeField] private string[] _answers = null;

    public bool CheckAnswer(string answer) => _answers.Contains(answer.ToLower());

    public string Question => _question;
}
