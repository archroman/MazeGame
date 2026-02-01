using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal sealed class InGameMenuPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartGameButton;

        [SerializeField] private SceneController _sceneController;
        [SerializeField] private CursorController _cursorController;

        private void Awake()
        {
            _panel.SetActive(false);
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OpenMainMenu);
            _restartGameButton.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OpenMainMenu);
            _restartGameButton.onClick.RemoveListener(RestartGame);
        }

        public void OpenInGameMenu()
        {
            _cursorController.UnlockCursor();
            _panel.SetActive(true);
        }

        private void OpenMainMenu()
        {
            _sceneController.LoadScene("MainMenu");
            
            if (Time.timeScale == 0)
                Time.timeScale = 1;
        }

        private void RestartGame()
        {
            _sceneController.RestartScene();

            if (Time.timeScale == 0)
                Time.timeScale = 1;
        }
    }
}