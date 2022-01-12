using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy")]
public class SO_Enemy : ScriptableObject
{
    public int maxHealth;
    public float speed;
    public float stopDistance;
    public TrashType enemyTrashType;
    public float spawnTime;
    public int damage;

    public SO_Trash smallTrashDrop;
    public SO_Trash largeTrashDrop;
    public float dropTime;
    public float largeDropPossibility;
    public int deathDropAmount;

}
