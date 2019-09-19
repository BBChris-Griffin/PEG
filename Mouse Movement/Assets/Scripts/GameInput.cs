using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public float speed;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.StopPlayback();
        //animator.StartRecording(0);
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        animator.SetFloat("Motion", translation);
        animator.speed = Mathf.Abs(translation);
    }
}
