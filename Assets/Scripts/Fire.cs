using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private PlayerManager _playerManager;
    private Transform _enemy;
    private BulletPool _bulletPool;

    private void Start()
    {
        _playerManager.Shoot.AddListener(SetTarget);
        _bulletPool = FindObjectOfType<BulletPool>();
    }

    private void SetTarget(Transform enemy, string str)
    {
        _enemy = enemy;
        var seq = DOTween.Sequence();
        seq.Append(_target.DOMove(new Vector3(enemy.position.x, enemy.position.y, enemy.position.z), 0.3f));
        seq.OnComplete(Shoot);
    }
    private void Shoot()
    {
        _shotPoint.LookAt(_target);
        var bullet = _bulletPool.GetBullet();
        bullet.Init(_shotPoint.position, _enemy.position);
        _target.DOLocalMove(new Vector3(0f, 1.6f, 1.8f), 0.3f);

    }
}
