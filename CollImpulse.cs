using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointCont), typeof(Rigidbody), typeof(PointColContDetect))]
    public class CollImpulse : MonoBehaviour
    {
        private PointCont _pointsContainer;
        private Rigidbody _rigidbody;
        private PointColContDetect _detector;

        private void Start()
        {
            _pointsContainer = GetComponent<PointCont>();
            _rigidbody = GetComponent<Rigidbody>();
            _detector = GetComponent<PointColContDetect>();
            Colstart();
        }
        
        private void OnCollisionStart(PointCont col)
        {
            if (col.points == _pointsContainer.points)
                _rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            
        }

        private void Colstart()
        {
            _detector.onCollisionStart += OnCollisionStart;
        }

        private void ColFinish()
        {
            _detector.onCollisionStart -= OnCollisionStart;
        }

        private void OnDestroy()
        {
            ColFinish();
        }
    }
}
