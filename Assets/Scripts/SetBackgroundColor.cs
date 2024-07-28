using UnityEngine;

public class SetBackgroundColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the Camera component attached to this GameObject then set the background color to black
        Camera camera = GetComponent<Camera>();
        camera.backgroundColor = Color.black;
    }
}
