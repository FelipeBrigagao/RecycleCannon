using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorHelper : MonoBehaviour
{
    private void Awake()
    {
        SetCurrentCollector();
    }

    private void SetCurrentCollector()
    {
        CollectorManager.Instance.SetCurrentCollector(this.gameObject);
    }
}
