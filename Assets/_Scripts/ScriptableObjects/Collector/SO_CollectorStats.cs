using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collector", menuName = "Collector")]
public class SO_CollectorStats : ScriptableObject
{
    public int maxHealth;
    public float speed;
    public float turnDamp;
    public Vector3 interactionBoxSize;
    public Vector3 interactionBoxOffset;
}
