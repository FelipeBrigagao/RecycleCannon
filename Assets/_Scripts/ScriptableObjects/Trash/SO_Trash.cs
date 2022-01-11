using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Trash", menuName = "Trash")]
public class SO_Trash : ScriptableObject
{
    public TrashType trashType;
    public GameObject interactablePrefab;
    public GameObject carryingPrefab;
    public TrashSize trashSize;
    public Sprite trashIcon;
    public SO_Ammo ammo;

}
public enum TrashType
{
    ORGANIC,
    METAL,
    PLASTIC
}

public enum TrashSize
{
    SMALL,
    LARGE
}
