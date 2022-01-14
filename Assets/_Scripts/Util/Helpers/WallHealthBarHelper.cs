using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealthBarHelper : MonoBehaviour
{
    [SerializeField] private HealthBar wallHealthBar;

    private void Awake()
    {
        SetWallHealthBar();
    }
    private void SetWallHealthBar()
    {
        UIManager.Instance.SetWallHealthBar(wallHealthBar);
    }
}
