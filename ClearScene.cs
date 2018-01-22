using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScene : MonoBehaviour {
    public Button yourButton;
    //public List<GameObject> createdObjects = new List<GameObject>();
	TestInstanstiation testForObjects;
	public GameObject PlaceHolderObject;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

		PlaceHolderObject = GameObject.Find("PlaceHolderObject");

    }

    void TaskOnClick()
    {
		// testForObjects = GetComponent<TestInstanstiation>();
		
		// if (testForObjects.createdObjects.Count >= 1){
		// 	foreach (Transform child in PlaceHolderObject.transform){
		// 	GameObject.Destroy(child.gameObject);
		// 	}
		// }

			foreach (Transform child in PlaceHolderObject.transform){
			GameObject.Destroy(child.gameObject);
			}
        Debug.Log("You have clicked the clear scene button!");
    }
}
