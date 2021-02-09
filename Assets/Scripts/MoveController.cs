using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MoveController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _active = false;
    [SerializeField] private float _breakDelay = 2f;
    [SerializeField] private float _minDisplacement = 0.2f;
    [SerializeField] private Minion _minion = null;
    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            _background.raycastTarget = _active;
        }
    }

    private Image _background = null;
    private float _timer = 0f;
    private Vector3 _startMousePosition = Vector3.zero;

    private void Awake()
    {
        _background = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!Active) return;

        _timer = 0f;
        _startMousePosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!Active) return;
        if (_timer >= _breakDelay) return;

        Vector3 displacement = Input.mousePosition - _startMousePosition;
        if (Mathf.Abs(displacement.x / Screen.width) < _minDisplacement) return;

        if (displacement.x > 0)
            _minion.WayNumber++;
        else
            _minion.WayNumber--;
    }

    private void Update()
    {
        if (!Active) return;
        _timer += Time.deltaTime;
    }
}
