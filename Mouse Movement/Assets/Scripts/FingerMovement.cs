using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMovement : MonoBehaviour
{
    public float speed;
    private Transform position;
    private bool clicked;
    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>();
        clicked = false;
    }

    private void Update()
    {
        if(clicked)
        {
            float translationY = Input.GetAxis("Mouse Y") * speed;
            float translationX = Input.GetAxis("Mouse X") * speed;
            //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            // Make it move 10 meters per second instead of 10 meters per frame...
            translationY *= Time.deltaTime;
            translationX *= Time.deltaTime;
            //rotation *= Time.deltaTime;

            // Move translation along the object's z-axis
            transform.Rotate(translationX, 0, translationY);
        }
    }

    //private void OnMouseDrag()
    //{
    //    Debug.Log("Dragged");
    //    float translationY = Input.GetAxis("Mouse Y") * speed;
    //    float translationX = Input.GetAxis("Mouse X") * speed;
    //    //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

    //    // Make it move 10 meters per second instead of 10 meters per frame...
    //    translationY *= Time.deltaTime;
    //    translationX *= Time.deltaTime;
    //    //rotation *= Time.deltaTime;

    //    // Move translation along the object's z-axis
    //    transform.Translate(0, translationY, translationX);
    //}

    private void OnMouseDown()
    {
        clicked = !clicked;
    }
}
