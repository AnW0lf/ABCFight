using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BotQuestController : QuestController
{
    public override void Begin(QuestionData questionData)
    {
        StartCoroutine(Utils.DelayedCall(3.2f, () => Submit()));
    }

    public override void Submit()
    {
        int count = Random.Range(5, 5);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) sb.Append("a");
        OnSubmit?.Invoke(sb.ToString());
    }
}
