using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class FailedUI : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    // Start is called before the first frame update

    private void OnEnable()
    {
        ballController.OnFailed += FailedUIShow;
    }

    private void OnDisable()
    {
        ballController.OnFailed -= FailedUIShow;
    }

    private void FailedUIShow()
    {
        SceneManager.LoadScene("FailedScene");
    }
}
