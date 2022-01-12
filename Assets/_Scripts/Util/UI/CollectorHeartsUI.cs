using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorHeartsUI : MonoBehaviour
{
    #region Variables
    [Header("Hearts UI references")]
    [SerializeField] private Transform _heartsHolder;
    [SerializeField] private GameObject _heartPrefab;
    private List<GameObject> _hearts = new List<GameObject>();
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void SetCollectorHearts(int health)
    {
        for(int i = 0; i < health; i++)
        {
            _hearts.Add(Instantiate(_heartPrefab, _heartsHolder));
        }
    }

    public void UpdateHealthUI(int health)
    {
        if(health < _hearts.Count)
        {
            while (health < _hearts.Count)
            {
                Destroy(_hearts[_hearts.Count - 1]);
                _hearts.RemoveAt(_hearts.Count -1);
            }
        }else if(health > _hearts.Count)
        {
            while (health > _hearts.Count)
            {
                _hearts.Add(Instantiate(_heartPrefab, _heartsHolder));
            }
        }
    }

    #endregion
}
