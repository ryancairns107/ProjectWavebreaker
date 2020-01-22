using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPiece : MonoBehaviour
{
    public GameObject toSpawn;
    public bool Spawned = false;
    public string toMatch = "";
    public GameObject toDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
        {
        //Debug.Log(other.gameObject.name);
        if (!Spawned && other.gameObject.name == "Character")
        {
            Instantiate(toSpawn, transform.position, transform.rotation);
            Spawned = true;
            toDestroy = GameObject.FindGameObjectWithTag("SubDestroy");
            if(toDestroy != null)
            {
                Destroy(toDestroy);
            }
        }        
    }
}
