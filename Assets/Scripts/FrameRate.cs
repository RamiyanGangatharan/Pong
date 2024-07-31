using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = -1;
    }
}
