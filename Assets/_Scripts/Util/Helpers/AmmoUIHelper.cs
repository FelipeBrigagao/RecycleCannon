using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUIHelper : MonoBehaviour
{
    [SerializeField] private IconUI _ammoUI;

    private void Awake()
    {
        SetAmmoUI();
    }

    private void SetAmmoUI()
    {
        UIManager.Instance.SetAmmoUI(_ammoUI);
    }
}
