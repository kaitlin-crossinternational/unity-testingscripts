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
  
     public Button yourButton;

     public string buttonLabel; 

//create an object of class PopulateDropdown since we need to listen to that script 
     public PopulateDropdown getDropdownValue; 
     private string dropdownValue;


     public int counter; 

     void Start() {
        counter = 0; 
		         
		Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

		PlaceHolderObject = GameObject.Find("PlaceHolderObject");

        buttonLabel = "choose a model";
        yourButton.GetComponentInChildren<Text>().text = buttonLabel;



     }

     void update (){
        //GameObject.Find("buttonName").GetComponentInChildren<Text>().text = "la di da";
		Button btn = yourButton.GetComponent<Button>();


        
        btn.GetComponentInChildren<Text>().text = buttonLabel;

        getDropdownValue =  GameObject.Find("InstantiatePrefab").GetComponent<PopulateDropdown>();
        dropdownValue = getDropdownValue.CurrentDropdownValue; 
        buttonLabel = dropdownValue;
        yourButton.GetComponentInChildren<Text>().text = buttonLabel;



     }
     void TaskOnClick() {

        counter++; 
       // buttonLabel = getDropdownValue.GetComponent<PopulateDropdown>().CurrentDropdownValue.ToString(); 
        //Debug.Log(buttonLabel);
        Debug.Log("get the dropdown value and it is: " + dropdownValue);
        yourButton.GetComponentInChildren<Text>().text = buttonLabel +" "+ counter.ToString() + dropdownValue;

      // buttonLabel = getDropdownValue.GetComponent<PopulateDropdown>().ToString(); 

            if (createdObjects.Count == 0){
		    if (equipPrefab != null){
             Vector3 position = new Vector3(0,0, 0);
 
             // instantiate the object
             GameObject go = (GameObject)Instantiate(equipPrefab, position, Quaternion.identity);
			 go.transform.parent = GameObject.Find("PlaceHolderObject").transform;
             createdObjects.Add(go);
                     Debug.Log("You have added a prefab");

         	}
            }else{
                //do nothing 
                Debug.Log("model already present");
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