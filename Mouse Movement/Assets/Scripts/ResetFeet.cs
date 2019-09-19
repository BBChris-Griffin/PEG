using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFeet : MonoBehaviour
{
    public Transform[] foot;
    public Transform[] shin;
    public Transform[] thigh;

    private Vector3[] thighPos;
    private Quaternion[] thighRot;
    private Vector3[] shinPos;
    private Quaternion[] shinRot;
    private Vector3[] footPos;
    private Quaternion[] footRot;

    private LegMovement[] thighMovement;
    private LegMovement[] shinMovement;
    private LegMovement[] footMovement;
    private KneeGrab[] kneeMovement;

    // Start is called before the first frame update
    void Start()
    {
        thighPos = new Vector3[thigh.Length];
        thighRot = new Quaternion[thigh.Length];
        shinPos = new Vector3[thigh.Length];
        shinRot = new Quaternion[thigh.Length];
        footPos = new Vector3[thigh.Length];
        footRot = new Quaternion[thigh.Length];

        for(int i = 0; i < foot.Length; i++)
        {
            thighPos[i] = thigh[i].position;
            thighRot[i] = thigh[i].rotation;
            shinPos[i] = shin[i].position;
            shinRot[i] = shin[i].rotation;
            footPos[i] = foot[i].position;
            footRot[i] = foot[i].rotation;
        }
        

        GameObject[] thighObject = GameObject.FindGameObjectsWithTag("Thigh");
        GameObject[] shinObject = GameObject.FindGameObjectsWithTag("Shin");
        GameObject[] footObject = GameObject.FindGameObjectsWithTag("Foot");
        GameObject[] kneeObject = GameObject.FindGameObjectsWithTag("Knee");

        thighMovement = new LegMovement[thighObject.Length];
        shinMovement = new LegMovement[shinObject.Length];
        footMovement = new LegMovement[footObject.Length];
        kneeMovement = new KneeGrab[kneeObject.Length];

        for(int i = 0; i < thighObject.Length; i++)
        {
            if (thighObject[i] != null)
            {
                thighMovement[i] = thighObject[i].GetComponent<LegMovement>();
            }
            if (shinObject[i] != null)
            {
                shinMovement[i] = shinObject[i].GetComponent<LegMovement>();
            }
            if (footObject[i] != null)
            {
                footMovement[i] = footObject[i].GetComponent<LegMovement>();
            }
            if (kneeObject[i] != null)
            {
                kneeMovement[i] = kneeObject[i].GetComponent<KneeGrab>();
            }
        }        
   
    }

    public void ResetTransform()
    {
        for(int i = 0; i < thigh.Length; i++)
        {
            thigh[i].position = thighPos[i];
            thigh[i].rotation = thighRot[i];
            shin[i].position = shinPos[i];
            shin[i].rotation = shinRot[i];
            foot[i].position = footPos[i];
            foot[i].rotation = footRot[i];
        }

        for(int i = 0; i < thighMovement.Length; i++)
        {
            thighMovement[i].UnselectLeg();
            shinMovement[i].UnselectLeg();
            footMovement[i].UnselectLeg();
            kneeMovement[i].UnselectLeg();
        }
    }
}
