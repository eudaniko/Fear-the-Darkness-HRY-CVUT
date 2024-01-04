using System;
using TMPro;
using UnityEngine;

namespace FtDCode.Core
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private void Start()
        {
            scoreText.text = "Score: " + PlayerPrefs.GetInt("Score", 0).ToString("00000");
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString("00000");
        }
    }
}
