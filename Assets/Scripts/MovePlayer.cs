using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private MultiAimConstraint _multiAim;
    [SerializeField] private WaitPoint[] _targetsPoint;
    private int _currentTarget;
    private const float MULTIAIMMIN = 0;
    private const float MULTIAIMMAX = 1;
    private void Start()
    {
        _playerManager.Move.AddListener(Move);
    }

    private void Update()
    {
        if (_animator.GetBool("RUN"))
        {
            _meshAgent.SetDestination(_targetsPoint[_currentTarget].transform.position);
        }
        if (Vector3.Distance(transform.position, _targetsPoint[_currentTarget].transform.position) < 1f)
        {
            _meshAgent.isStopped = true;
            _animator.SetBool("RUN", false);
            _multiAim.weight = MULTIAIMMAX;
        }
    }

    private void Move()
    {
        _animator.SetBool("RUN", true);
        _multiAim.weight = MULTIAIMMIN;
        SelectTarget();
        _meshAgent.isStopped = false;
    }

    private void SelectTarget()
    {
        if (_currentTarget < _targetsPoint.Length - 1)
            _currentTarget++;
        else
            _currentTarget = _targetsPoint.Length - 1;
    }
}
