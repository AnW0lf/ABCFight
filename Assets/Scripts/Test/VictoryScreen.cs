using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private RectTransform _label = null;

    private bool _victory = false;

    public void Begin()
    {
        if (_victory) return;
        _victory = true;
        _label.gameObject.SetActive(true);
        StartCoroutine(Utils.CrossFading(
            Vector3.up * 500f, Vector3.zero, 0.4f,
            (position) => _label.anchoredPosition = position,
            (a, b, c) => Vector3.Lerp(a, b, c)
            ));
    }
}
