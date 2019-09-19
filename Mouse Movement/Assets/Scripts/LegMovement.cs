using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
    public float speed;
    public Material skin;
    public Shader highlight;
    public Shader hoverShader;
    public Shader skinShader;
    private Transform position;
    private bool clicked;
    private bool rightClicked;
    public bool modifiedMotion = false;
    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>();
        clicked = false;
        rightClicked = false;
        skinShader = skin.shader;
    }

    private void Update()
    {
        if (clicked)
        {
            float translationY = Input.GetAxis("Mouse Y") * speed;
            float translationX = Input.GetAxis("Mouse X") * speed;

            // Make it move 10 meters per second instead of 10 meters per frame...
            translationY *= Time.deltaTime;
            translationX *= Time.deltaTime;

            if(modifiedMotion)
            {
                transform.Rotate(0, translationX, translationY);
            }
            else
            {
                // Move rotation 
                transform.Rotate(translationX, translationY, 0);
            }
            
        }
        else if (rightClicked)
        {
            float translationY = Input.GetAxis("Mouse Y") * speed;
            float translationX = Input.GetAxis("Mouse X") * speed;

            translationY *= Time.deltaTime;
            translationX *= Time.deltaTime;

            // Move translations
            transform.Translate(translationX, translationY, 0);
        }
    }

    private void OnMouseDown()
    {
        clicked = true;
        skin.shader = highlight;
    }

    private void OnMouseOver()
    {
        if(!clicked)
        {
            skin.shader = hoverShader;
        }

        // Just in case this needs to be used as well
        if (Input.GetMouseButtonDown(1))
        {
            rightClicked = true;
            skin.shader = highlight;
        }
    }

    private void OnMouseExit()
    {
        if(!clicked)
        {
            skin.shader = skinShader;
        }
    }

    public void UnselectLeg()
    {
        clicked = false;
        rightClicked = false;
        skin.shader = skinShader;
    }

    private void OnApplicationQuit()
    {
        skin.shader = skinShader;
    }

    public void AutoSelect()
    {
        clicked = true;
    }
}
