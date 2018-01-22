 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using System.Collections.Generic;
 
 // rename this class to suit your needs
 public class TestInstanstiation : MonoBehaviour
 {
     // the Equip prefab - required for instantiation
	 // in the inspector add the prefab desired. 
     public GameObject equipPrefab;
     public GameObject PlaceHolderObject;  

     
     // list that holds all created objects
     public List<GameObject> createdObjects = new List<GameObject>();
  
    //private List <GameObject> availableObjects = new List<GameObject>();
    //public static GameObject[] availableObjects; 
    public List <GameObject> myAvailablePrefabs = new List<GameObject>();

     public Button yourButton;

     public string buttonLabel; 

//create an object of class PopulateDropdown since we need to listen to that script 
     public PopulateDropdown getDropdownValue; 
     private string dropdownValue;

    public int prefabArrayIndex;
     public int counter; 

     void Start() {
        counter = 0; 
		         
		Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

		PlaceHolderObject = GameObject.Find("PlaceHolderObject");

        buttonLabel = "choose a model";
        yourButton.GetComponentInChildren<Text>().text = buttonLabel;

    prefabArrayIndex = 0;
            getDropdownValue =  GameObject.Find("prefabSelectorDropdown").GetComponent<PopulateDropdown>();


    //need to look in the file directory for all the desired files, as in populatedropdown script
    Object[] subListObjects = Resources.LoadAll("Prefabs");
    foreach (GameObject subListObject in subListObjects){
        GameObject myPrefabObjects = (GameObject)subListObject;
        myAvailablePrefabs.Add(myPrefabObjects);
    }
            Debug.Log("added " + myAvailablePrefabs.Count + " prefabs to list"); 
           // myAvailablePrefabs.siz
     }

     void update (){
        //GameObject.Find("buttonName").GetComponentInChildren<Text>().text = "la di da";
		// Button btn = yourButton.GetComponent<Button>();


        
        // btn.GetComponentInChildren<Text>().text = buttonLabel;

        // getDropdownValue =  GameObject.Find("InstantiatePrefab").GetComponent<PopulateDropdown>();
        // dropdownValue = getDropdownValue.CurrentDropdownValue; 
        // buttonLabel = dropdownValue;
        // yourButton.GetComponentInChildren<Text>().text = buttonLabel;



     }
     void TaskOnClick() {

         //get the dropdown script, to get the array index of the current object selected. 
        prefabArrayIndex = getDropdownValue.indexOfSelectedValue; 
        Debug.Log("array index is: " + prefabArrayIndex);

        //counter++; 
        //Debug.Log(buttonLabel);
        Debug.Log("get the dropdown value and it is: " + dropdownValue);


            if (createdObjects.Count == 0){
		    if (myAvailablePrefabs[prefabArrayIndex] != null){
             Vector3 position = new Vector3(0,0, 0);
 
             // instantiate the object
             GameObject go = (GameObject)Instantiate(myAvailablePrefabs[prefabArrayIndex], position, Quaternion.identity);
			 go.transform.parent = GameObject.Find("PlaceHolderObject").transform;
             createdObjects.Add(go);
                     Debug.Log("You have added a prefab of index: " + prefabArrayIndex);

         	}
            }else{

                //remove first child of game object so that only one model displays at a time
                Destroy(PlaceHolderObject.transform.GetChild(0).gameObject);

                //when there is already a model present but you have selected a different model to place 
            //                  Vector3 position = new Vector3(0,0, 0);;
            //                  GameObject go = (GameObject)Instantiate(myAvailablePrefabs[prefabArrayIndex], position, Quaternion.identity);
			//  go.transform.parent = GameObject.Find("PlaceHolderObject").transform;
            //  createdObjects.Add(go);
                createdObjects.RemoveAt(0);
                Vector3 position = new Vector3(0,0, 0);

                GameObject nextSculpture = (GameObject)Instantiate(myAvailablePrefabs[prefabArrayIndex], position, Quaternion.identity);
                nextSculpture.transform.parent = GameObject.Find("PlaceHolderObject").transform;
                Debug.Log("model already present, adding different model");
                Debug.Log("You have added a prefab of index: " + prefabArrayIndex);

                createdObjects.Add(nextSculpture);


            }
			 	if (createdObjects.Count >= 2){
				    foreach (Transform child in PlaceHolderObject.transform){
					    GameObject.Destroy(child.gameObject);
				}
			}
    }
    //  public void CreateObject()
    //  {
    //      // a prefab is need to perform the instantiation

    //  }    
 }