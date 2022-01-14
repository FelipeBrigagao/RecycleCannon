using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy")]
public class SO_Enemy : ScriptableObject
{
    public GameObject enemyPrefab;
    public int maxHealth;
    public float speed;
    public float enemyStopDistance;
    public float wallStopDistance;
    public TrashType enemyTrashType;
    public float spawnTime;

    public float attackRange;
    public Vector3 attackAreaOffset;
    public int damage;
    public float collectorAttackDuration;
    public float wallAttackRate;

    public SO_Trash smallTrashDrop;
    public SO_Trash largeTrashDrop;
    public float dropTime;
    public float largeDropPossibility;
    public int deathDropAmount;

}
