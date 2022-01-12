using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet")]
public class SO_Ammo : ScriptableObject
{
    public GameObject bulletPrefab;
    public TrashType bulletType;
    public float bulletSpeed;
    public float bulletMaxDistance;
    public int bulletDamage;
    public int ammoAmount;
    public Sprite ammoTypeIcon;
}
