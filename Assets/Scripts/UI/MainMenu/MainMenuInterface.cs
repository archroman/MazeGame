using System;
using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    internal sealed class MainMenuInterface : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuPanel;

        [SerializeField] private Button _playButton;

        [SerializeField] private SceneController _sceneController;

        private void Awake()
        {
            _mainMenuPanel.SetActive(true);
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(StartGame);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            _sceneController.LoadScene("GameScene");
        }
    }
}