using System.Collections;
using UnityEngine;

public class BulletsShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] float _shootingDelay;
    [SerializeField] Target _target;

    private void Start()
    {
        StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        bool isActive = true;
        WaitForSeconds waitForSeconds = new(_shootingDelay);

        while (isActive)
        {
            Vector3 distance = (_target.transform.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bulletPrefab, transform.position + distance, Quaternion.identity);

            newBullet.SetDirection(_target);

            yield return waitForSeconds;
        }
    }
}