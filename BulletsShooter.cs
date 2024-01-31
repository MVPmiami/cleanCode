using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] float _shootingDelay;

    public Transform Target;

    private void Start() {
        StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        bool isActive = true;

        while (isActive)
        {
            Vector3 distance = (Target.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_bulletPrefab, transform.position + distance, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().transform.up = distance;
            newBullet.GetComponent<Rigidbody>().velocity = distance * _speed;

            yield return new WaitForSeconds(_shootingDelay);
        }
    }
}