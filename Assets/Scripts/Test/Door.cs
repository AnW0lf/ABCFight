using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public UnityAction<Door, Navigator> OnEnterDoor { get; set; } = null;

    public bool Questioned { get; set; } = false;

    private List<Navigator> _navigators = new List<Navigator>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out NavMeshAgent agent))
        {
            Navigator navigator = FindObjectsOfType<Navigator>().First((n) => n.ContainsAgent(agent));
            if (!Questioned)
            {
                Questioned = true;
                OnEnterDoor?.Invoke(this, navigator);
            }
            _navigators.Add(navigator);
            navigator.Active = false;
        }
    }

    private void OnDestroy()
    {
        foreach (var navigator in _navigators)
            navigator.Active = true;
    }
}
