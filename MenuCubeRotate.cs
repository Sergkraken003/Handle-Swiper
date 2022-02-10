using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCubeRotate : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(0.5f, 0.5f, 0.5f);
    }
}
