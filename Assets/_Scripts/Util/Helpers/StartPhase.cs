using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.StartPhase();
    }
}
