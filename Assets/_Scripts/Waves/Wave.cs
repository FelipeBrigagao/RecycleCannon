using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    public string waveName;
    public SO_Enemy[] enemiesToSpawn;
    public float waveDuration;
}