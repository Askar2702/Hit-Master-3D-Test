using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public bool IsAlive { get; private set; }
    [SerializeField] private Animator _animator;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _health;
    [SerializeField] private Slider _slider;
    private Camera _camera;
    private Rigidbody[] _rigidbodies;
    private void Awake()
    {
        _camera = Camera.main;
        _slider.maxValue = _health;
        _slider.value = _health;
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }
    private void Start()
    {
        SetKinematicRigidBody(true);
        IsAlive = true;
    }
    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0) _health = 0;
        _slider.value = _health;
        SetKinematicRigidBody(false);
        if (_health <= 0)
        {
            _slider.gameObject.SetActive(false);
            IsAlive = false;
        }
        else StartCoroutine(Rise());
    }

    private void LateUpdate()
    {
        _canvas.transform.LookAt(_canvas.transform.position + _camera.transform.forward);
    }


    IEnumerator Rise()
    {
        yield return new WaitForSeconds(2f);
        _animator.enabled = true;
        SetKinematicRigidBody(true);
    }
    private void SetKinematicRigidBody(bool activ)
    {
        _animator.enabled = activ;
        for (int i = 0; i < _rigidbodies.Length; i++)
            _rigidbodies[i].isKinematic = activ;
    }
}
