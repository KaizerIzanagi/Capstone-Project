using TMPro;
using UnityEngine;

public class PhaseTimer : MonoBehaviour
{
    [SerializeField] private float _phaseTimer;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _phaseEndIndicator;
    [SerializeField] private TextMeshProUGUI _timerText;
    void Awake()
    {
        _phaseTimer = 120f;
        _timer = GameObject.FindGameObjectWithTag("PhaseTimer");
        _phaseEndIndicator = GameObject.FindGameObjectWithTag("MultiUI");
        _timerText = _timer.GetComponent<TextMeshProUGUI>();
        _phaseEndIndicator.SetActive(false);
    }
    void Update()
    {
        _phaseTimer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(_phaseTimer / 60);
        int seconds = Mathf.FloorToInt(_phaseTimer % 60);
        _timerText.text = "Time Until Chamber Floods: " + "\n" + string.Format("{0:00}:{1:00}", minutes, seconds);

        if (_phaseTimer <= 0)
        {
            _phaseEndIndicator.SetActive(true);
        }
    }
}
