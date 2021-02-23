using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _notification = null;

    private Queue<string> _requests = new Queue<string>();

    private Coroutine _flying = null;
    private Color _solid, _transparent;

    public void Request(string text) => _requests.Enqueue(text);

    private void Start()
    {
        _solid = _notification.color;
        _transparent = _solid;
        _transparent.a = 0f;
    }

    private void Update()
    {
        if (_requests.Count > 0 && _flying == null)
        {
            _flying = StartCoroutine(Fly(_requests.Dequeue()));
        }
    }

    private IEnumerator Fly(string text)
    {
        _notification.gameObject.SetActive(true);
        _notification.text = text;
        _notification.color = _solid;
        _notification.transform.localPosition = Vector3.zero;

        yield return StartCoroutine(Utils.CrossFading(
            Vector3.zero,
            Vector3.one,
            0.6f,
            (scale) => _notification.transform.localScale = scale,
            (a, b, c) => Vector3.Lerp(a, b, c)
            ));

        StartCoroutine(Utils.DelayedCall(0.5f, () =>
        {
            StartCoroutine(Utils.CrossFading(
            _solid,
            _transparent,
            0.6f,
            (color) => _notification.color = color,
            (a, b, c) => Color.Lerp(a, b, c)
            ));
        }));

        yield return StartCoroutine(Utils.CrossFading(
            _notification.transform.localPosition,
            _notification.transform.localPosition + Vector3.up * 200f,
            1.2f,
            (position) => _notification.transform.localPosition = position,
            (a, b, c) => Vector3.Lerp(a, b, c)
            ));

        _notification.gameObject.SetActive(false);

        _flying = null;
    }
}
