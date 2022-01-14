using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables
    [Header("Ammo values")]
    [SerializeField] private SO_Bullet _bulletInfo;

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
        _bulletLifeSpawn = _bulletInfo.bulletMaxDistance / _bulletInfo.bulletSpeed;
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(BulletLifeCountdown());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(_enemyTag))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                switch (_bulletInfo.bulletType)
                {
                    case TrashType.ORGANIC:
                        if (enemyHealth._enemyTrashType == TrashType.METAL || enemyHealth._enemyTrashType == TrashType.PLASTIC || enemyHealth._enemyTrashType == TrashType.ALL)
                        {
                            enemyHealth.TakeDamage(_bulletInfo.bulletDamage);
                        }
                        break;
                    case TrashType.METAL:
                        if (enemyHealth._enemyTrashType == TrashType.ORGANIC ||  enemyHealth._enemyTrashType == TrashType.ALL)
                        {
                            enemyHealth.TakeDamage(_bulletInfo.bulletDamage);
                        }
                        break;
                    case TrashType.PLASTIC:
                        if (enemyHealth._enemyTrashType == TrashType.ORGANIC || enemyHealth._enemyTrashType == TrashType.ALL)
                        {
                            enemyHealth.TakeDamage(_bulletInfo.bulletDamage);
                        }
                        break;
                }
            }

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
        _rigidbody.MovePosition(transform.position + transform.forward * _bulletInfo.bulletSpeed * Time.deltaTime);
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
