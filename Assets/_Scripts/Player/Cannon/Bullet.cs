using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables
    [Header("Ammo values")]
    [SerializeField] private SO_Ammo _ammoInfo;

    [Header("Bullet references")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private string _enemyTag;
    private float _bulletLifeSpawn;
    private bool _bulletCanMove;
    #endregion

    #region Unity Methods
    private void Start()
    {
        _bulletCanMove = true;
        _bulletLifeSpawn = _ammoInfo.bulletMaxDistance / _ammoInfo.bulletSpeed;
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(BulletLifeCountdown());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(_enemyTag))
        {
            //tirar vida do inimigo se o tipo do inimigo for o certo para o tipo de munição
        }
        StopAllCoroutines();
        BulletImpact();
    }

    private void FixedUpdate()
    {
        if (_bulletCanMove)
        {
            MoveBullet();
        }
    }
    #endregion

    #region Methods
    private void MoveBullet()
    {
        _rigidbody.MovePosition(transform.position + transform.forward * _ammoInfo.bulletSpeed * Time.deltaTime);
    }

    private void BulletImpact()
    {
        _bulletCanMove = false;
        Destroy(this.gameObject); //substituir pela animação de explosão do tiro de energia
    }

    IEnumerator BulletLifeCountdown()
    {
        yield return new WaitForSeconds(_bulletLifeSpawn);
        BulletImpact();
    }
    #endregion
}
