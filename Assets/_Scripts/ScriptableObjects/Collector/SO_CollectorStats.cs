using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collector", menuName = "Collector")]
public class SO_CollectorStats : ScriptableObject
{
    public int health;
    public float speed;
    public float turnDamp;
}
