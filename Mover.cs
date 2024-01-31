using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _speed;
    private int _targetPlaceIndex;
    private Transform[] _places;
    private Transform _placesPoint;

    private void Start() {
        _places = new Transform[_placesPoint.childCount];

        for (int i = 0; i < _placesPoint.childCount; i++)
            _places[i] = _placesPoint.GetChild(i).GetComponent<Transform>();
    }
=
    private void Update()
    {
        var targetPlace = _places[_targetPlaceIndex];

        transform.position = Vector3.MoveTowards(transform.position, targetPlace.position, _speed * Time.deltaTime);

        if (transform.position == targetPlace.position)
            GetTargetPosition();
    }

    private Vector3 GetTargetPosition(){
        var targetPosition = _places[_targetPlaceIndex].transform.position;

        if (_targetPlaceIndex == _places.Length)
            _targetPlaceIndex  = 0;

        transform.forward = targetPosition - transform.position;
        _targetPlaceIndex++;

        return targetPosition;
    }
}