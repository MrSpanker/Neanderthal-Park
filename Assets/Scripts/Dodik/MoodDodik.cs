using UnityEngine;
using UnityEngine.UI;

public class MoodDodik : MonoBehaviour
{
    [SerializeField] private Slider _moodSlider;
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] Image _fillImage;
    [SerializeField] Image _backgroundImage;
    [SerializeField] Sprite[] _moodlesSprites;
    [SerializeField] Color[] _moodlesColors;

    private bool _stopMood;
    private void Update()
    {
        if(_stopMood == false)
            _moodSlider.value -= Time.deltaTime * _speed;

        if(_moodSlider.value > 0.7f)
        {
            _fillImage.color = _moodlesColors[0];
            _backgroundImage.sprite = _moodlesSprites[0];
        }
        else if(_moodSlider.value < 0.7f && _moodSlider.value > 0.4f)
        {
            _fillImage.color = _moodlesColors[1];
            _backgroundImage.sprite = _moodlesSprites[1];
        }
        else if(_moodSlider.value < 0.4f)
        {
            _fillImage.color = _moodlesColors[2];
            _backgroundImage.sprite = _moodlesSprites[2];
        }
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
