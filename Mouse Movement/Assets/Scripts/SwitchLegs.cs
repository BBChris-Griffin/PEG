using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLegs : MonoBehaviour
{

    public GameObject leg;
    public Transform[] transforms;
    private int legNum;
    // Start is called before the first frame update
    void Start()
    {
        legNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            legNum++;
            //leg.transform.position = transforms[legNum % (transforms.Length - 1)].position;
            leg.transform.position = transforms[1].position;
            leg.transform.rotation = transforms[1].rotation;

        }
    }
}
