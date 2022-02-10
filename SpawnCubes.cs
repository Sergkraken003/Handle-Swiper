using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ChainCube.Scripts.Utils
{
    [RequireComponent(typeof(ISwipeDetector))]
    public class SpawnCubes : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 0.3f;

        [SerializeField] private GameObject _cubePrefab;

        [SerializeField] private GameObject _swipeDetectorObj;

        [SerializeField] Text GameScore;

        [SerializeField] Text TopScore;


        private CubeDependencsInj[] _cubeDependencs;
        
        private ISwipeDetector _swipeDetect;

        private Coroutine _spawnRoutine;

        private int score = 0;


        
        private void Start()
        {
            _swipeDetect = _swipeDetectorObj.GetComponent<ISwipeDetector>();
            _cubeDependencs = FindObjectsOfType<CubeDependencsInj>();
            SpawnStart();
            TopScore.text = "TOP SCORE: "  + PlayerPrefs.GetInt("topscore").ToString();
        }
        private void Update()
        {
            TopScore.text = "TOP SCORE: "  + PlayerPrefs.GetInt("topscore").ToString();
            SaveTopScore();
            UpdateScore();
        }
        private void SpawnStart()
        {
            _swipeDetect.onSwipeEnd += OnSwipeEnd;
        }

        private void SpawnFinish()
        {
            _swipeDetect.onSwipeEnd -= OnSwipeEnd;
        }

        private void OnSwipeEnd(Vector2 delta)
        {
            if (_spawnRoutine == null)
                _spawnRoutine = StartCoroutine(SpawnWithDelay());
        }

        private IEnumerator SpawnWithDelay()
        {
            yield return null;
            yield return new WaitForSeconds(_spawnDelay);
            var instance = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            InjectCube(instance.gameObject);
            _spawnRoutine = null;
        }

        private void InjectCube(GameObject cube)
        {
            foreach (var dependency in _cubeDependencs)
            {
                dependency.Cube = cube;
            }
        }

        private void OnDestroy()
        {
            SpawnFinish();
        }
        
        private void UpdateScore()
        {
           GameScore.text = score.ToString("SCORE: ");
        }

        private void UpdateTopScore()
        {
            TopScore.text = "Top Score: "  + PlayerPrefs.GetInt("topscore").ToString();
        }

        private void SaveTopScore()
        {
            int oldBestScore = PlayerPrefs.GetInt("topscore");

            if (score > oldBestScore)
            {
                PlayerPrefs.SetInt("topscore", score);
            }
        }
    }
}