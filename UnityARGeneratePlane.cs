using System;
using System.Collections.Generic;

namespace UnityEngine.XR.iOS
{
	public class UnityARGeneratePlane : MonoBehaviour
	{
        Collider planeCollider;
        Vector3 planeCenter;
        GameObject whateverCube;
      //  public double oscillateTime;
        public float rotateSpeed = 10f;

        //make a list of the planes generated so we can isolate the first plane 
        public List<GameObject> allThePlanes; 
		public GameObject planePrefab;
        private UnityARAnchorManager unityARAnchorManager;

		// Use this for initialization
		void Start () {
            Debug.Log("Called UNITYARGENERATEPLANE.CS");
            allThePlanes = new List<GameObject>();
            unityARAnchorManager = new UnityARAnchorManager();
			UnityARUtility.InitializePlanePrefab (planePrefab);


            planeCollider = planePrefab.GetComponent<Collider>();
            planeCenter = planeCollider.bounds.center;

            whateverCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            whateverCube.transform.parent = planePrefab.transform;
            whateverCube.transform.position = planeCenter;

            allThePlanes.Add(planePrefab);

            Debug.Log("planes detected are: " + allThePlanes.Count);

            //translate to AR world scale (10%)
            //move .05 units up so that the cube sits on the plane
                        whateverCube.transform.localScale = new Vector3(.1f,.1f,.1f);
            whateverCube.transform.position = new Vector3(0,.05f,0);
            //whateverCube.transform.localScale = new Vector3(planeCenter.x * 0.1f ,planeCenter.y * 0.1f ,planeCenter.z * 0.1f );

         //   GameObject go = Instantiate(whateverCube,planeCenter,Quaternion.identity);
		}

        void OnDestroy()
        {
            unityARAnchorManager.Destroy ();
        }

        void OnGUI()
        {
            List<ARPlaneAnchorGameObject> arpags = unityARAnchorManager.GetCurrentPlaneAnchors ();
            if (arpags.Count >= 1) {
                //ARPlaneAnchor ap = arpags [0].planeAnchor;
                //GUI.Box (new Rect (100, 100, 800, 60), string.Format ("Center: x:{0}, y:{1}, z:{2}", ap.center.x, ap.center.y, ap.center.z));
                //GUI.Box(new Rect(100, 200, 800, 60), string.Format ("Extent: x:{0}, y:{1}, z:{2}", ap.extent.x, ap.extent.y, ap.extent.z));
            }
        }

        void update(){
            whateverCube.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            // planeCollider = planePrefab.GetComponent<Collider>();
            // planeCenter = planeCollider.bounds.center;

        }
	}
}

