using System;
using ChainCube.Scripts.Utils;
using UnityEngine;

namespace ChainCube.Scripts.Handlers
{
    public class ForceYMovementSwipeHandler : MonoBehaviour, IMovableObjectHandler
    {
        [SerializeField]
        private float _force = 1.0f;
        
        private Rigidbody _movableRigidBody;
        private ISwipeDetector _swipeDetector;
        
        public void Inject(GameObject dependency)
        {
            _movableRigidBody = dependency.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _swipeDetector = GetComponent<MouseSwipeDetect>();
            SwpipeDetect();
        }

        private void SwpipeDetect()
        {

            _swipeDetector.onSwipeEnd += OnSwipeEnd;
        }

        private void OnSwipeEnd(Vector2 delta)
        {
            if (_movableRigidBody == null)
                return;
            
            _movableRigidBody.AddForce(_movableRigidBody.transform.forward * _force, ForceMode.Impulse);
            _movableRigidBody = null;
        }

        private void OnDestroy()
        {
            returnDetect();
        }

        private void returnDetect()
        {
            if (_swipeDetector == null)
                return;

            _swipeDetector.onSwipeEnd -= OnSwipeEnd;
        }
    }
}

