using UnityEngine;

namespace Settings
{
    internal sealed class CursorController : MonoBehaviour
    {
        private bool _isCursorLocked = true;

        public bool IsCursorLocked => _isCursorLocked;

        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isCursorLocked = true;
        }

        public void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isCursorLocked = false;
        }
    }
}