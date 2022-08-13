using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    [SerializeField] private float _force = 5000;
    public Rigidbody Rb;
    private BulletPool _bulletPool;
    private bool isFire;
    private Vector3 _direction;
    void Awake()
    {
        _bulletPool = FindObjectOfType<BulletPool>();
    }
    void FixedUpdate()
    {
        if (isFire)
        {
            transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);
        }
    }
    public void Init(Vector3 startPos, Vector3 direction)
    {
        transform.position = startPos;
        Rb.isKinematic = false;
        _direction = direction;
        isFire = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isFire) return;
        if (collision.transform.GetComponentInParent<Enemy>())
        {
            if (collision.gameObject.name == "Head")
            {
                collision.transform.GetComponentInParent<Enemy>().TakeDamage(_damage * 100);
            }
            else collision.transform.GetComponentInParent<Enemy>().TakeDamage(_damage);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * _force, ForceMode.Force);
        }
        isFire = false;
        _bulletPool.AddPool(this);
        Rb.isKinematic = true;
        gameObject.SetActive(false);
    }

}
