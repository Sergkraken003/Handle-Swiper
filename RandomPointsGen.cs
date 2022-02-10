using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointCont))]
    public class RandomPointsGen : MonoBehaviour
    {
        [SerializeField] private byte _minDegree = 1;

        [SerializeField] private byte _maxDegree = 4;
        
        private PointCont _pointsContain;

        private const byte defaultMinDegree = 1;
        private const byte defaultMaxDegree = 4;

        private void Start()
        {
            NormalizeDegree();
            _pointsContain = GetComponent<PointCont>();
            _pointsContain.points = (int)Mathf.Pow(2, Random.Range(_minDegree, _maxDegree));
        }

        private void NormalizeDegree()
        {
            if (_maxDegree > _minDegree) return;
            
            _minDegree = defaultMinDegree;
            _maxDegree = defaultMaxDegree;
        }
    }
}
