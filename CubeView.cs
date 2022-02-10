using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointCont))]
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private TextMeshPro[] _texts;
        [SerializeField] private List<MaterialSettings> _settings = new List<MaterialSettings>();

        private PointCont _container;

        private void Start()
        {
            _container = GetComponent<PointCont>();
            SetPoints(_container.points);
            ContanOnPoint();
        }
        
        private void SetPoints(long points)
        {
            foreach (var text in _texts)
            {
                text.text = points.ToString();
                var settings = _settings.Find(t => t.points == points);
                
                if (settings == null)
                    _renderer.material = default;
                else
                    _renderer.material = settings.material;
            }
        }

        private void ContanOnPoint()
        {
            _container.onPointsChanged += SetPoints;
        }
        
        private void ContanUnPoint()
        {
            _container.onPointsChanged -= SetPoints;
        }

        private void OnDestroy()
        {
            ContanUnPoint();
        }
    }

    [System.Serializable]
    public class MaterialSettings
    {
        public long points;
        public Material material;
    }
}
