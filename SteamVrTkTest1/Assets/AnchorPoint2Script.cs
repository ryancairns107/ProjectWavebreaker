using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPoint2Script : MonoBehaviour
{
    [SerializeField]
    public GameObject Gun;
    public GameObject cloneableAnchorPost;
    public GameObject secondRopePoint;
    public GameObject linkedAnchor;
    public GameObject linkedRopePoint;
    public GameObject cloneableRope;

    //public bool Reloaded;
  
    public bool CollidedAlready2 = false;
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
        if (CollidedAlready2 == false)
        {
            CollidedAlready2 = true;
            Debug.Log("Bullet2 Collided");
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            CreateAnchorPoint2(position, rotation);
        }
    }
    void CreateAnchorPoint2(Vector3 CollisionPos, Quaternion rotation)
    {
        GameObject secondPost = Instantiate(cloneableAnchorPost, CollisionPos, rotation);
        Debug.Log("Anchor2 Made");

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("AnchorPost");
        secondRopePoint = (gos[gos.Length-1]).transform.GetChild(0).gameObject;
        Debug.Log("Second Rope Point:  " + secondRopePoint);
        CreateRope();

        //Reloaded = true;
        //Debug.Log("AP2 reloaded true");
        Destroy(this);
        
    }
    public void PopulateFields(GameObject myGun, GameObject baseAnchor)
    {
        Gun = myGun;
        Debug.Log(Gun);
        //Reloaded = true;
        linkedAnchor = baseAnchor;
        linkedRopePoint = linkedAnchor.transform.GetChild(0).gameObject;
        Debug.Log("First Rope Point:  " + linkedRopePoint);
    }
    void CreateRope()
    {
        Vector3 firstPos = linkedRopePoint.transform.position;
        Debug.Log("1st Anchor Position: " + firstPos.x + ", " + firstPos.y + ", " + firstPos.z);
        float x1 = firstPos.x;
        float y1 = firstPos.y;
        float z1 = firstPos.z;

        Vector3 secondPos = secondRopePoint.transform.position;
        Debug.Log("2nd Anchor Position: " + secondPos.x + ", " + secondPos.y + ", " + secondPos.z);
        float x2 = secondPos.x;
        float y2 = secondPos.y;
        float z2 = secondPos.z;


        float midpointX = (firstPos.x + secondPos.x) / 2;
        float midpointY = (firstPos.y + secondPos.y) / 2;
        float midpointZ = (firstPos.z + secondPos.z) / 2;

        float ropeLength = Mathf.Sqrt(Mathf.Pow((x2-x1),2)+ Mathf.Pow((y2-y1),2)+ Mathf.Pow((z2-z1),2));        //distance formula for first and second anchor locations
        ropeLength = ((float)(ropeLength * 1));
        Debug.Log("Rope Length is:    " + ropeLength);

        Vector3 ropePos = new Vector3(midpointX, midpointY, midpointZ);     //midpoint formula to place rope at center between
        float ropeRot = Vector3.Angle(firstPos, secondPos);
        Instantiate(cloneableRope, ropePos, Quaternion.identity);
        Debug.Log("Rope Created at :  " + ropePos);
        GameObject[] ropes;
        ropes = GameObject.FindGameObjectsWithTag("Ropes");
        Debug.Log("Last Found Rope:  " + ropes[ropes.Length-1]);
        //Debug.Log("Rope Scales:  " + ropes[ropes.Length - 1].transform.localScale);
        //ropes[ropes.Length - 1].transform.localScale = new Vector3(0.025f, ropeLength, 0.025f);
        //Debug.Log("Rope Rotation:  " + ropes[ropes.Length - 1].transform.localRotation);



        var dir = linkedRopePoint.transform.position - secondRopePoint.transform.position;
        var mid = (dir) / 2.0f + linkedRopePoint.transform.position;
        ropes[ropes.Length-1].transform.position = mid;
        ropes[ropes.Length - 1].transform.position = ropePos;
        ropes[ropes.Length - 1].transform.position = ropePos;
        ropes[ropes.Length - 1].transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Vector3 scale = ropes[ropes.Length - 1].transform.localScale;
        scale.y = dir.magnitude * 0.5f;
        ropes[ropes.Length - 1].transform.localScale = scale;

        //ropes[ropes.Length - 1].transform.localScale = new Vector3(0f, ropeLength, 1);
        //secondRopePoint = (ropes[ropes.Length - 1])




    }
}
