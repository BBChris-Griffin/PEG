using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KneeGrab : MonoBehaviour
{
    public Material skin;
    public Shader highlight;
    public Shader hoverShader;
    public Shader skinShader;
    private bool clicked;
    private LegMovement[] thighMovement;
    private LegMovement[] shinMovement;

    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
        skinShader = skin.shader;

        GameObject[] thighObject = GameObject.FindGameObjectsWithTag("Thigh");
        GameObject[] shinObject = GameObject.FindGameObjectsWithTag("Shin");

        thighMovement = new LegMovement[thighObject.Length];
        shinMovement = new LegMovement[shinObject.Length];

        for (int i = 0; i < thighObject.Length; i++)
        {
            if (thighObject[i] != null)
            {
                thighMovement[i] = thighObject[i].GetComponent<LegMovement>();
            }
            if (shinObject[i] != null)
            {
                shinMovement[i] = shinObject[i].GetComponent<LegMovement>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < thighMovement.Length; i++)
        {
            thighMovement[i].AutoSelect();
            shinMovement[i].AutoSelect();
        }
        clicked = true;
        skin.shader = highlight;
    }

    private void OnMouseOver()
    {
        if (!clicked)
        {
            skin.shader = hoverShader;
        }
    }

    private void OnApplicationQuit()
    {
        skin.shader = skinShader;
    }

    public void UnselectLeg()
    {
        clicked = false;
        skin.shader = skinShader;
    }

    private void OnMouseExit()
    {
        if (!clicked)
        {
            skin.shader = skinShader;
        }
    }
}
