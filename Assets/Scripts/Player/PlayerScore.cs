using System;
using TMPro;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        public event Action<int> ScoreChanged;

        private int _currentScore;

        private void Start()
        {
            UpdateScoreText();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Coin>(out Coin coin))
                return;

            AddScore(coin.Value);
            coin.gameObject.SetActive(false);
        }

        private void AddScore(int value)
        {
            _currentScore += value;
            UpdateScoreText();
            ScoreChanged?.Invoke(_currentScore);
        }

        private void UpdateScoreText()
        {
            if (_scoreText == null)
            {
                return;
            }

            _scoreText.text = $"Score: {_currentScore}";
        }

        public int Score => _currentScore;
    }
}