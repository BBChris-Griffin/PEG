using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFingers : MonoBehaviour
{
    private GameObject[] fingers;
    private Transform[] fingerTrans;

    // Start is called before the first frame update
    void Start()
    {
        fingers = new GameObject[5];
        fingers[0] = GameObject.FindGameObjectWithTag("Index");
        fingers[1] = GameObject.FindGameObjectWithTag("Middle");
        fingers[2] = GameObject.FindGameObjectWithTag("Pinky");
        fingers[3] = GameObject.FindGameObjectWithTag("Ring");
        fingers[4] = GameObject.FindGameObjectWithTag("Thumb");

        fingerTrans = new Transform[5];
        for (int i = 0; i < fingers.Length; i++)
        {
            fingerTrans[i].eulerAngles = fingers[i].GetComponent<Transform>().eulerAngles;
        }
    }

    public void onClick()
    {
        for(int i = 0; i < fingers.Length; i++)
        {
            fingers[i].GetComponent<Transform>().eulerAngles = fingerTrans[i].eulerAngles;
        }
    }
}
