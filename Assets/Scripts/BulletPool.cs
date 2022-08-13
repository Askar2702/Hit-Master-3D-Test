using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _count;
    private List<Bullet> _bullets = new List<Bullet>();

    private void Start()
    {
        for(int i = 0; i < _count; i++)
        {
            var bullet = Instantiate(_bullet);
            AddPool(bullet);
        }
    }

    public Bullet GetBullet()
    {
        Bullet bullet = _bullets[0];
        bullet.gameObject.SetActive(true);
        RemovePool(_bullets[0]);
        return bullet;
    }
    public void AddPool(Bullet bullet)
    {
        _bullets.Add(bullet);
    }
    
    private void RemovePool(Bullet bullet)
    {
        _bullets.Remove(bullet);
    }
}
