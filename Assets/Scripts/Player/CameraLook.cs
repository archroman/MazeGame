using Settings;
using UnityEngine;

namespace Player
{
    internal sealed class CameraLook : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _defaultMouseSensitivity = 25f; 
        [SerializeField] private float _scalingFactor = 100f; 
        [SerializeField] private CursorController _cursorController;

        private float _mouseSensitivity;
        private float _xRotation = 0f;

        private void Start()
        {
            _mouseSensitivity = _defaultMouseSensitivity;

            if (_cursorController != null)
                _cursorController.LockCursor();
        }

        private void Update()
        {
            if (_cursorController != null && !_cursorController.IsCursorLocked)
                return;

            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * _scalingFactor * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * _scalingFactor * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _player.Rotate(Vector3.up * mouseX);
        }
    }
}