using UnityEngine;
using Player;
using UI;

internal sealed class FinishPoint : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private InGameMenuPanel _inGameMenuPanel;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerScript>(out PlayerScript player) && _playerScore.Score >= 5)
        {
            Debug.Log($"Game over! You are winner! Your final score: {_playerScore.Score}");
            Time.timeScale = 0;
            _inGameMenuPanel.OpenInGameMenu();
        }
        else
        {
            Debug.Log("Try to find more coins in the maze!");
        }
    }
}