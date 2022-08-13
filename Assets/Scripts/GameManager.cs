using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider _lengtRoad;
    [SerializeField] private MovePlayer _player;
    [SerializeField] private WaitPoint _lastWaitPoint;

    private void Start()
    {
        _lengtRoad.maxValue = _lastWaitPoint.transform.position.z;
    }
    private void Update()
    {
        ChangeLengtRoad();
    }
    private void ChangeLengtRoad()
    {
        _lengtRoad.value = _player.transform.position.z;
    }
}
