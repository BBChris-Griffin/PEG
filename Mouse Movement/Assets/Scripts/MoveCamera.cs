using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Model
{
    public Quaternion modelRoation;
    public Camera cam;
}

public class MoveCamera : MonoBehaviour {

    public Model[] models;
    public float smoothing;
    public float speed;

    private int model;
    private int currModel;

    private void Start()
    {
        model = 1;
        currModel = model;
        for(int i = 1; i < models.Length; i++)
        {
            models[i].cam.enabled = false;
        }
        //StartCoroutine(Turn());
    }

    void Update ()
    {
        if (Input.GetKeyUp("right"))
        {
            model++;
        }
        else if(Input.GetKeyUp("left"))
        {
            model--;
        }

        if(model < 1)
        {
            model = models.Length;
        }
        else if(model > models.Length)
        {
            model = 1;
        }

        if(currModel != model)
        {
            models[model - 1].cam.enabled = true;
            models[currModel - 1].cam.enabled = false;
            currModel = model;
        }
       
    }

    //IEnumerator Turn()
    //{
    //    while(true)
    //    {
    //        if (currModel != model)
    //        {
    //            models[currModel].cam.GetComponent<Rigidbody>().position = Vector3.RotateTowards(models[currModel].cam.GetComponent<Transform>().forward,
    //                models[model].cam.GetComponent<Rigidbody>().position, speed * Time.deltaTime, 0.0f);
    //            yield return new WaitForSeconds(2f);
    //            models[model - 1].cam.enabled = true;
    //            models[currModel - 1].cam.enabled = false;
    //            currModel = model;
    //        }
    //        yield return new WaitForSeconds(0.25f);
    //    }
    //}
}
