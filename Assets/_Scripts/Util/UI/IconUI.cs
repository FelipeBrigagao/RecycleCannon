using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconUI : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private Text _iconDescription;

    public void UpdateIconUI(Sprite newIcon, string description)
    {
        _iconImage.enabled = true;
        _iconImage.sprite = newIcon;
        _iconDescription.enabled = true;
        _iconDescription.text = description;
    }

    public void UpdateDescription(string description)
    {
        _iconDescription.text = description;
    }

    public void CleanIconUI()
    {
        _iconImage.sprite = null;
        _iconImage.enabled = false;
        _iconDescription.enabled = false;
        _iconDescription.text = "";
    }
}