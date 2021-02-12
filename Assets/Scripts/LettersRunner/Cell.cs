using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Cell : MonoBehaviour
{
    [SerializeField] protected TextMeshPro _letter = null;
    [SerializeField] protected GameObject _effectPrefab = null;
    protected MeshRenderer _renderer = null;

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

    public bool Activated { get; protected set; } = false;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    protected virtual void ActivateCell(GameObject other)
    {
        if (!Activated && other.TryGetComponent(out Player player))
        {
            Activated = true;
            OnActivateCell?.Invoke(this);
            _letter.gameObject.SetActive(true);
            if (_effectPrefab != null)
            {
                GameObject effect = Instantiate(_effectPrefab, transform.position + Vector3.up, Quaternion.identity);
                Destroy(effect, 3f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivateCell(other.gameObject);
    }
}
