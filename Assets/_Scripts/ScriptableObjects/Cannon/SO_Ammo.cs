using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo", menuName = "Ammo")]
public class SO_Ammo : ScriptableObject
{
    public GameObject bulletPrefab;
    public int ammoAmount;
    public Sprite ammoTypeIcon;
}
