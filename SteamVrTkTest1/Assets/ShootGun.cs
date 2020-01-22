namespace VRTK.Examples
{
    using UnityEngine;

    public class ShootGun : MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        public GameObject theGun;
        public GameObject projectile1;
        public GameObject projectile2;
        public Transform projectileSpawnPoint;
        public float projectileSpeed = 1000f;
        public float projectileLife = 5f;
        public bool FirstShotAlready = false;
        public bool Reloaded = true;
        public GameObject AnchorStation;
        public int count = 0;


        void Start()
        {
        }

        protected virtual void OnEnable()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            }
        }

        protected virtual void OnDisable()
        {
            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }
        }
        private void Update()
        {
        }
        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
            Debug.Log("InteractObjectUsed");
            if (Reloaded == true)
            {
                count += 1;
                //Debug.Log("Count:  " + count);
                if (FirstShotAlready == false)
                {
                    FireProjectile1();
                    FirstShotAlready = true;
                }
                else
                {
                    GameObject[] gos;
                    gos = GameObject.FindGameObjectsWithTag("AnchorPost");
                    Debug.Log("Array Length:  " + gos.Length);
                    for (var i = 1; i < gos.Length; i++)
                    {
                        Debug.Log(i);
                        Debug.Log("Object #: " + i + ",  Data:  " + gos[i]);
                    }
                    CreateLinkPoint(gos[gos.Length-1]);
                    


                    FireProjectile2();
                    FirstShotAlready = false;
                }
            }
            else
            {
                Debug.Log("Gun Not Reloaded");
            }
        }

        protected virtual void FireProjectile1()
        {
            if (projectile1 != null && projectileSpawnPoint != null)
            {
                GameObject clonedProjectile = Instantiate(projectile1, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                Rigidbody projectileRigidbody = clonedProjectile.GetComponent<Rigidbody>();
                clonedProjectile.GetComponent<AnchorPoint1Script>().PopulateFields(theGun);
                float destroyTime = 0f;
                if (projectileRigidbody != null)
                {
                    projectileRigidbody.AddForce(clonedProjectile.transform.forward * projectileSpeed);
                    destroyTime = projectileLife;
                }
                Debug.Log("FirstProjectileShot");
                Destroy(clonedProjectile, destroyTime);
            }
        }
       protected virtual void FireProjectile2()
       {
            if (projectile1 != null && projectileSpawnPoint != null)
            {
                GameObject clonedProjectile = Instantiate(projectile2, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                Rigidbody projectileRigidbody = clonedProjectile.GetComponent<Rigidbody>();
                clonedProjectile.GetComponent<AnchorPoint2Script>().PopulateFields(theGun, AnchorStation);
                float destroyTime = 0f;
                if (projectileRigidbody != null)
                {
                    projectileRigidbody.AddForce(clonedProjectile.transform.forward * projectileSpeed);
                    destroyTime = projectileLife;
                }
                Debug.Log("SecondProjectileShot");
                Destroy(clonedProjectile, destroyTime);
            }
        }
    public void CreateLinkPoint(GameObject firstAnchor)
        {
            AnchorStation = firstAnchor;
        }
        public bool getreloadGun()
        {
            return Reloaded;
        }
        public bool setreloadGun(bool reloaded)
        {
            Reloaded = reloaded;
            return Reloaded;
        }
    }
}