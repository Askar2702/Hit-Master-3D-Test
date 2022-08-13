using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public UnityEvent<Transform, string> Shoot;
    public UnityEvent Move;
    private Enemy[] _enemyData;
    private bool isFire;
    private void Start()
    {
        _enemyData = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            FindClosestEnemy();
            if (Physics.Raycast(ray, out hit))
            {
                if (!hit.transform.GetComponent<Rigidbody>() || !isFire) return;
                Shoot?.Invoke(hit.transform, hit.transform.name);
            }
        }

    }

    private void FindClosestEnemy()
    {
        float distanceClosestEnemy = Mathf.Infinity;
        Enemy enemy = null;
        foreach (var enem in _enemyData)
        {
            if (enem.IsAlive)
            {
                float distenemy = (enem.transform.position - transform.position).sqrMagnitude;
                if (distenemy < distanceClosestEnemy)
                {
                    distanceClosestEnemy = distenemy;
                    enemy = enem;
                }
            }
        }
        if (enemy == null || Vector3.Distance(transform.position, enemy.transform.position) > 10f)
            NextPoint();
        else isFire = true;

    }
    private void NextPoint()
    {
        Move?.Invoke();
        isFire = false;
    }



}

