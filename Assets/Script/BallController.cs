using System;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 10f; 
    [SerializeField] private float deceleration = 0.1f;
    [SerializeField] private GameObject[] greenBalls;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    private Rigidbody _rb;
    private Vector3 _targetPosition;
    private bool _isMoving = false;
    
    private int _score = 0;
    private int _life = 10;

    private int _currentBall = 0;

    public event Action OnGameOver;
    public event Action OnFailed;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        PlayerPrefs.SetString("FailedScore","0");
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
    
    private bool IsClickOnTable()
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GreenBall"))
        {
            _currentBall++;
            Destroy(other.gameObject);
            _score++;
            scoreText.text = _score.ToString();
            
            if (_currentBall==greenBalls.Length)
            {
                print("GameOver");
                OnGameOver?.Invoke();
            }
        }
        
        else if (other.gameObject.CompareTag("RedBall"))
        {
            Destroy(other.gameObject);
            // Decrease life and update UI
            _life--;
            lifeText.text = _life.ToString();

            // Check for game over
            if (_life <= 0)
            {
                PlayerPrefs.SetString("FailedScore",scoreText.text);
                OnFailed?.Invoke();
            } 
        }
        
        else if(other.gameObject.CompareTag("Falls"))
        {
            PlayerPrefs.SetString("FailedScore",scoreText.text);
            OnFailed?.Invoke();
        }
        
    }
}
