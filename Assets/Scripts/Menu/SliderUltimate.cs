using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUltimate : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Ultimate _ultimate;

    public void ChangeSliderFilling(float score)
    {
        score = score % 1001;
        _slider.value = score / 1000;

        if (_slider.value == 1)
        {
            _ultimate.UseUltimate();
            _slider.value = 0;
        }
    }
}
