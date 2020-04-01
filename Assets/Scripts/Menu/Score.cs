using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private SliderUltimate _sliderUltimate;
    private int _score;
    private void Update()
    {
        if (Time.timeScale == 1)
        {
        _score++;
        _scoreText.text = " " + _score + " miles";
        _sliderUltimate.ChangeSliderFilling(_score);
        }
    }
}
