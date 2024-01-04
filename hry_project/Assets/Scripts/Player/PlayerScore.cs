using System;
using TMPro;
using UnityEngine;

namespace FtDCode.Player
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        public static int CurrentScore;
        private float _initialPlayerPositionY;
        private int _highScore;
        private const string ScorePref = "Score";
        private const string HighScorePref = "HighScore";

        private void Awake()
        {
            _initialPlayerPositionY = transform.position.y;
            CurrentScore = 0;
            _highScore = PlayerPrefs.GetInt(HighScorePref, 0);
        }

        private void Update()
        {
            CurrentScore = Mathf.FloorToInt(transform.position.y - _initialPlayerPositionY);
            scoreText.text = "Score: " + CurrentScore.ToString("00000");
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt(ScorePref, CurrentScore);
            if (CurrentScore <= _highScore) return;
            PlayerPrefs.SetInt(HighScorePref, CurrentScore);
        }
    }
}
