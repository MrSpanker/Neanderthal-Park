using UnityEngine;
using UnityEngine.UI;

public class MoodDodik : MonoBehaviour
{
    [SerializeField] private Slider _moodSlider;
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] Image _fill;
    private bool _stopMood;
    private void Update()
    {
        if(_stopMood == false)
            _moodSlider.value -= Time.deltaTime * _speed;

        if(_moodSlider.value > 0.7f)
            _fill.color = Color.green;
        else if(_moodSlider.value < 0.7f && _moodSlider.value > 0.4f)
            _fill.color = Color.yellow;
        else if(_moodSlider.value < 0.4f)
            _fill.color = Color.red;
    }
    public void StopMood()
    {
        _stopMood = true;
    }
    public void StartMood()
    {
        _stopMood = false;
    }

    public void PlusMood()
    {
        _moodSlider.value = 1f;
    }

}
