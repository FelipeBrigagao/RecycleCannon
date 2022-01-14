using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorInteractionButton : MonoBehaviour
{
    private CollectorInteraction _collectorInteract;

    private void Awake()
    {
        _collectorInteract = CollectorManager.Instance._currentCollector.GetComponent<CollectorInteraction>();
    }

    public void CollectorInteract()
    {
        _collectorInteract?.CheckInteraction();
    }
}
