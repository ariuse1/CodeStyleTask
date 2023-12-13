using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Transform AllPoints;
    [SerializeField] private float Speed;

    private Transform[] _points;
    private int _numberPoint;

    private void Awake()
    {
        _points = new Transform[AllPoints.childCount];

        for (int i = 0; i < AllPoints.childCount; i++)
            _points[i] = AllPoints.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform point = _points[_numberPoint];

        transform.position = Vector3.MoveTowards(transform.position, point.position, Speed * Time.deltaTime);

        if (transform.position == point.position) SelectNextPoint();
    }

    private void SelectNextPoint()
    {
        _numberPoint++;

        if (_numberPoint == _points.Length)
            _numberPoint = 0;

        Vector3 PointVector = _points[_numberPoint].transform.position;

        transform.forward = PointVector - transform.position;
    }
}
