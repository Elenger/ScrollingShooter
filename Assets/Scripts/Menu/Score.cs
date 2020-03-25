using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _score;
    private void Update()
    {
        _score++;
        _scoreText.text = _score.ToString() + " miles";
    }
}
