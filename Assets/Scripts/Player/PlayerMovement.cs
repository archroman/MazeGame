using System;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private Rigidbody _rigidbody;
        private Vector3 _direction;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            _direction = transform.forward * vertical + transform.right * horizontal;
            _direction = Vector3.ClampMagnitude(_direction, 1f);
        }

        [Obsolete("Obsolete")]
        private void FixedUpdate()
        {
            _rigidbody.velocity = _direction * _speed;
        }
    }
}