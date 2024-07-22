using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackgroundColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the Camera component attached to this GameObject
        Camera camera = GetComponent<Camera>();

        // Set the background color to black
        camera.backgroundColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
