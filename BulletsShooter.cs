using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsShooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] float _shootingDelay;

    public Transform Target;

    private void Start() 
    {
        StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        bool isActive = true;
        IEnumerator waitForSeconds = new WaitForSeconds(_shootingDelay);

        while (isActive)
        {
            Vector3 distance = (Target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bulletPrefab, transform.position + distance, Quaternion.identity);
            newBullet.transform.up = distance;
            newBullet.velocity = distance * _speed;

            yield return waitForSeconds();
         }
    }
}