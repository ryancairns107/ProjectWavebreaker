using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPoint1Script : MonoBehaviour
{
    [SerializeField]
    public GameObject Gun;
    public bool collidedAlready = false;
    public GameObject cloneableAnchorPost;
    //private bool Reloaded;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collidedAlready == false)
        {
            collidedAlready = true;
            Debug.Log("Bullet1 Collided");
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            CreateAnchorPoint1(position, rotation);
        }
    }
    void CreateAnchorPoint1(Vector3 CollisionPos, Quaternion rotation)
    {        
        Instantiate(cloneableAnchorPost, CollisionPos, rotation);
        Debug.Log("Anchor1Made");


        Destroy(this);
        
    }
    public void PopulateFields(GameObject myGun)
    {
        Gun = myGun;

    }
}
