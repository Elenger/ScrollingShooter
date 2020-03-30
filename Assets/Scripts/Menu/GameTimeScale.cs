using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeScale : MonoBehaviour
{
    [SerializeField] private int _gameState;
    public void PauseGame()
    {
        Time.timeScale = _gameState;
    }
}
