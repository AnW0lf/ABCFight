using UnityEngine;

public class FinishCell : Cell
{
    protected override void ActivateCell(GameObject other)
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

            FindObjectOfType<WordSetter>().Finishing(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivateCell(other.gameObject);   
    }
}
