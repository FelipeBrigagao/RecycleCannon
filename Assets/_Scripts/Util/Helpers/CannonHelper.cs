using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonHelper : MonoBehaviour
{
    private void Awake()
    {
        SetCurrentCannon();
    }

    private void SetCurrentCannon()
    {
        CannonManager.Instance.SetCurrentCannon(this.gameObject);
    }
}
