using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Cell : MonoBehaviour
{
    [SerializeField] private TextMeshPro _letter = null;
    [SerializeField] private GameObject _effectPrefab = null;
    private MeshRenderer _renderer = null;

    public UnityAction<Cell> OnActivateCell { get; set; } = null;

    public Color CellColor
    {
        get => _renderer.material.color;
        set => _renderer.material.color = value;
    }

    public Color LetterColor
    {
        get => _letter.color;
        set => _letter.color = value;
    }

    public string Letter
    {
        get => _letter.text;
        set => _letter.text = value;
    }

    public bool Activated { get; private set; } = false;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Activated && other.TryGetComponent(out Player player))
        {
            //print($"{player.name} enters {gameObject.name}");
            Activated = true;
            OnActivateCell?.Invoke(this);
            _letter.gameObject.SetActive(true);
            if(_effectPrefab != null)
            {
                GameObject effect = Instantiate(_effectPrefab, transform.position + Vector3.up, Quaternion.identity);
                Destroy(effect, 3f);
            }
        }
    }
}
