using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//created by Kaitlin Schaer 1/16/18

//a script to instantiate prefabs as children of the HitCubeParent GameObject. Prefabs must have the model, all textures, and their necessary scripts already attached. 
//0,0,0 of the models should be the center of the base of the sculpture
 
public class AddPrefabToPlaceholder : MonoBehaviour {
	
	// Use this for initialization
	public GameObject ElonMuskPrefab;
	//public GameObject HitCubeParent;
	public GameObject PlaceHolderObject;
	public Transform HitCubeTransform; 
	//public Transform addPrefabToHitcube; 

	void Start () {
		
	}
	void SpawnElonMusk (){
		Debug.Log("spawning elon musk");
		GameObject elonMusk = Instantiate(ElonMuskPrefab) as GameObject; 
		HitCubeTransform = GameObject.Find("HitCubeParent").transform; 
		//transform the prefab ElonMuskPrefab to the location of the hit cube
		elonMusk.transform.SetParent(HitCubeTransform, false);

	}
	public List<GameObject> childObjects; 
	public string CurrentPrefab;
	public string DesiredPrefab;


//boolean to test whether there are any children of the HitCube GameObject 
	// private bool HitCubeHasChildren(Transform pTransform){
	// 	int count = 0;
	// 	foreach(Transform child in pTransform){
	// 		count++;
	// 	}
	// 	if(count>0){return true;}else{return false;}; 
	// }
}