using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MoveController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _active = false;
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

    public bool Holded { get; private set; } = false;

    private Image _background = null;
    private float _startMinionXCoord = 0f;
    private Vector3 _startMousePosition = Vector3.zero;

    private void Awake()
    {
        _background = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!Active) return;

        _startMousePosition = Input.mousePosition;
        _startMinionXCoord = _minion.XCoord;

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

        float offset = (Input.mousePosition - _startMousePosition).x / Screen.width * 3f;
        _minion.XCoord = _startMinionXCoord + offset * 1.5f;
    }
}
