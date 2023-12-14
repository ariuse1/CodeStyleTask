using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private float _timeWait;
    [SerializeField] private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;
        WaitForSeconds timeWait = new WaitForSeconds(_timeWait);

        while (isWork)
        {
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;

            yield return timeWait;
        }
    }
}