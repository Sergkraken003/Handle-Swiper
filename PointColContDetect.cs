using System;
using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    public class PointColContDetect : MonoBehaviour
    {
        public event Action<PointCont> onCollisionStart;
        public event Action<PointCont> onCollisionContinue;

        private void OnCollisionEnter(Collision col)
        {
            var colContain = col.gameObject.GetComponent<PointCont>();

            if (colContain == null)
                return;
            
            onCollisionStart?.Invoke(colContain);
            onCollisionContinue?.Invoke(colContain);
        }
    }
}
