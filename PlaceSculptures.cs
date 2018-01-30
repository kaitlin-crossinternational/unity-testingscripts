using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.XR.iOS;

//goal: create a list of instances of the UnityArGeneratePlane.cs script. Do stuff to instance of script at a specified index
//eg; add the first sculpture to the first found plane, add the second sculpture to the next plane. 
public class PlaceSculptures : MonoBehaviour {

	public UnityARGeneratePlane planeGenerationMethod;
	public List<UnityARGeneratePlane> targetPlanes; 

	public List<GameObject> planeObjects;

	public int planeCount;
	 
	public Button myButton;

	// Use this for initialization
	void Start () {
		Button btn = myButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void TaskOnClick(){
		Debug.Log("CLICK CLICK CLICK");
		//create a list of the UNITYARGENERATEPLANE script instances by finding gameobjects with it attached? 
		// GameObject[] go = GameObject.FindGameObjectsWithTag("planeTag");
		// foreach (GameObject planeScriptInstances in go){
		// 	UnityARGeneratePlane doPlaneGeneration = planeScriptInstances.GetComponent<UnityARGeneratePlane>();
		// 	if (doPlaneGeneration != null) { targetPlanes.Add(doPlaneGeneration);} else { Debug.LogError("nopenopenope");}
		// }

		// GameObject myCapsule = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Capsule),new Vector3(0,0,0),Quaternion.identity);
		// myCapsule.transform.parent = go[0].transform; 
		// myCapsule.transform.localScale = new Vector3(.2f,.2f,.4f);

		// while (targetPlanes[0]){
		// 	GameObject myCube = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube),new Vector3(0,0,0),Quaternion.identity);
		// myCube.transform.parent = go[0].transform; 
		// myCube.transform.localScale = new Vector3(.2f,.4f,.1f);
		// }



		//in the list of all the script instances, look for all objects with a certain tag and add those to an object list 

		planeObjects = new List <GameObject>(); 
		
			GameObject[] foundPlaneList = GameObject.FindGameObjectsWithTag("planeTag"); 
			foreach (GameObject foundSinglePlane in foundPlaneList){
				planeObjects.Add(foundSinglePlane);
				planeCount++;

				Debug.Log("HEY plane counter is " + planeCount);
			
		}


		//



	}
}
