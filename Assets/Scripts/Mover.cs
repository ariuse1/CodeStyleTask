using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _allPoints;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _numberPoint;

    private void Awake()
    {
        _points = new Transform[_allPoints.childCount];

        for (int i = 0; i < _allPoints.childCount; i++)
            _points[i] = _allPoints.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform point = _points[_numberPoint];

        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (transform.position == point.position) 
            SelectNextPoint();
    }

    private void SelectNextPoint()
    {
        _numberPoint++;

        if (_numberPoint == _points.Length)
            _numberPoint = 0;

        Vector3 pointVector = _points[_numberPoint].transform.position;

        transform.forward = pointVector - transform.position;
    }
}
