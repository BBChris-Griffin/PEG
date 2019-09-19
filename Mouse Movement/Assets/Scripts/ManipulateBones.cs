using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateBones : MonoBehaviour
{
    public Transform bone;
    // Use this for initialization
    void Start()
    {
        bone = GetComponent<Transform>().Find("Armature/Arm");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Called");
            if (bone != null)
            {
                bone.eulerAngles = new Vector3(0, 0, 90);
                Debug.Log("bone is real!");
            }
            else
            {
                Debug.Log("bone is null!");
            }

        }
    }
    //void LateUpdate()
    //{
    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        if (bone != null)
    //        {
    //            bone.eulerAngles = new Vector3(0, 0, 90);      
    //            Debug.Log("bone is real!");
    //        }
    //        else
    //        {
    //            Debug.Log("bone is null!");
    //        }

    //    }

    //}
}
