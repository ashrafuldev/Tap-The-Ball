using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScore;
    // Start is called before the first frame update
    private void Start()
    {
        currentScore.text = PlayerPrefs.GetString("FailedScore");
    }

    
}
