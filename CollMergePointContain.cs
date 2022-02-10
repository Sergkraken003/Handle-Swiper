using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointCont), typeof (PointCont))]
    public class CollMergePointContain : MonoBehaviour
    {
        private PointCont _pointsContainer;
        private PointColContDetect _detector;

        private void Start()
        {
            _pointsContainer = GetComponent<PointCont>();
            _detector = GetComponent<PointColContDetect>();
            DetectContinue();
        }

        private void OnPointsContainerCollision(PointCont col)
        {
            if (col.points == _pointsContainer.points)
            {
                _pointsContainer.points *= 2;
                Destroy(col.gameObject);
            }
        }

        private void DetectContinue()
        {
            _detector.onCollisionContinue += OnPointsContainerCollision;
        }
        
        private void DetectUnContinue()
        {
            _detector.onCollisionContinue -= OnPointsContainerCollision;
        }

        private void OnDestroy()
        {
            DetectUnContinue();
        }
    }
}
