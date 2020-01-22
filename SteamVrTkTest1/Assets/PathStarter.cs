using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathStarter : MonoBehaviour
{

    public bool pathStarted = false;
    public GameObject PathFollowObject;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //IsColliding()
    //private void OnCollisionEnter(Collision collision)
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger enter");
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            if (!pathStarted)
            {
                Debug.Log("Starting Path");
                pathStarted = true;
            }
        }        
    }

}
