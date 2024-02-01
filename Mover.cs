using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private float _speed;

    private int _targetPlaceIndex;
    private Transform[] _places;

    private void Start() 
    {
        _places = new Transform[_pointContainer.childCount];

        for (int i = 0; i < _places.Length; i++)
            _places[i] = _pointContainer.GetChild(i)
    }

    private void Update()
    {
        var targetPlace = _places[_targetPlaceIndex];

        transform.position = Vector3.MoveTowards(transform.position, targetPlace.position, _speed * Time.deltaTime);

        if (transform.position == targetPlace.position)
            Move();
    }

    private void Move()
    {
        Vector3 targetPosition = _places[_targetPlaceIndex].transform.position;

        _targetPlaceIndex = _targetPlaceIndex++ % _places.Length;
        transform.forward = targetPosition - transform.position;
    }
}