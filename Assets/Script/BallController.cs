
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f; 
    [SerializeField] private float deceleration = 0.1f; 

    private Rigidbody _rb;
    private Vector3 _targetPosition;
    private bool _isMoving = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsClickOnTable())
            {
                _targetPosition = GetTargetPosition();
                _isMoving = true; 
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isMoving = false;
        }

        if (_isMoving)
        {
            MoveTowardsTarget();
        }
        else
        {
            Decelerate();
        }
    }
    
    bool IsClickOnTable()
    {
       var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return false;
        return hit.collider.CompareTag("Table");
    }

    private Vector3 GetTargetPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            return hit.point;
        }
        return transform.position;
    }

    private void MoveTowardsTarget()
    {
        var direction = (_targetPosition - transform.position).normalized;
        _rb.velocity = direction * speed;
    }

    private void Decelerate()
    {
        _rb.velocity *= Mathf.Pow(1f - deceleration, Time.deltaTime * 10f);
    }
}
