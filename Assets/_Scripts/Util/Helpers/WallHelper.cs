using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHelper : MonoBehaviour
{
    private void Awake()
    {
        SetCurrentWall();
    }

    private void SetCurrentWall()
    {
        WallManager.Instance.SetCurrentWall(this.gameObject);
    }
}
