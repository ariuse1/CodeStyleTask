using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _timeWait;

    public Transform ObjectToShoot;    

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = true;
        WaitForSeconds timeWait = new WaitForSeconds(_timeWait);

        while (isWork)
        {
            Vector3 direction = (ObjectToShoot.position - transform.position).normalized;
            GameObject NewBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = direction;
            NewBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return timeWait;
        }
    }
}