using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private GameObject[] _effects = null;

    private bool _enabled = false;
    public bool Enabled
    {
        get => _enabled;
        set
        {
            _enabled = value;
            foreach (var effect in _effects)
                effect.SetActive(_enabled);
        }
    }
}
