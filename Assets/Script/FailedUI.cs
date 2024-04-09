using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedUI : MonoBehaviour
{
    [SerializeField] private BallController _ballController;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _ballController.OnFailed += FailedUIShow;
    }

    private void OnDisable()
    {
        _ballController.OnFailed -= FailedUIShow;
    }

    private void FailedUIShow()
    {
        SceneManager.LoadScene("FailedScene");
    }
}
