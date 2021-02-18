using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MoveController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _active = false;
    [SerializeField] private Transform _navigator = null;
    [SerializeField] private float _sensitivity = 3f;
    [SerializeField] private float _width = 5f;
    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            _background.raycastTarget = _active;
        }
    }

    public bool Holded { get; private set; } = false;

    private Image _background = null;
    private float _startNavigatorX = 0f;
    private Vector3 _startMousePosition = Vector3.zero;

    private void Awake()
    {
        _background = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!Active) return;

        _startMousePosition = Input.mousePosition;
        _startNavigatorX = _navigator.position.x;

        Holded = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!Active) return;
        Holded = false;
    }

    private void Update()
    {
        if (!Active) return;
        if (!Holded) return;

        float offset = (Input.mousePosition - _startMousePosition).x / Screen.width * _sensitivity;

        Vector3 position = _navigator.position;
        position.x = Mathf.Clamp(_startNavigatorX + offset, -_width / 2f, _width / 2f);
        _navigator.position = position;
    }
}
