using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//created by Kaitlin Schaer on 1/17/18. 
//this script creates a list of all the prefabs in the Prefabs folder and populates a dropdown menu based on it. 

//note: the string manipulation here is based on the directory setup of my specific computer; modify as necessary. 
public class PopulateDropdown : MonoBehaviour {


	DirectoryInfo prefabDirectory;
	public List<string> createdObjects = new List<string>();
	List<Dropdown.OptionData> menuOptions;
	public Dropdown prefabSelectorDropdown; 

	//public Text CurrentPrefabSelected; 
	public string CurrentPrefabSelected; 
	public string CurrentDropdownValue;

	private TestInstanstiation otherButton;

	public int indexOfSelectedValue;
	void Start () {
		indexOfSelectedValue = 0; 
		//get the files at the desired location, only with the extension .prefab
		prefabDirectory = new DirectoryInfo("Assets/Resources/Prefabs");
		FileInfo[] prefabInfo = prefabDirectory.GetFiles("*.prefab"); 

		foreach (FileInfo f in prefabInfo){
			string fileString = f.ToString();
			//this specifically is filepath that needs to be considered: 
			//manipulate the string to get just the name:
			string shortFileString = fileString.Substring(92);
			string fileNameString = shortFileString.Substring(0, shortFileString.Length-13);
			createdObjects.Add(fileNameString);
		}
		// there is now a list "createdObjects" of all the prefabs available. 
		foreach (string str in createdObjects){
			Debug.Log("here is a prefab file I found: " + str);
		}

		//fetch the dropdown object that this script is attached to, clear its components and add new ones from the list
		prefabSelectorDropdown = GetComponent<Dropdown>();
		prefabSelectorDropdown.ClearOptions();
		prefabSelectorDropdown.AddOptions(createdObjects); 

		//add the listener for any change in the dropdown menu here: 
		prefabSelectorDropdown.onValueChanged.AddListener(delegate {
			DropdownValueChanged(prefabSelectorDropdown);
		});

		//get the options back as a list again: useful for sending data to other buttons
		menuOptions = prefabSelectorDropdown.GetComponent<Dropdown>().options; 
//what????
		otherButton =  GameObject.Find("InstantiatePrefab").GetComponent<TestInstanstiation>();
	}
	
	//call this method when the dropdown value changes. since we don't need this info all of the time,
	//it is useful just to call when it is changed: 
	void DropdownValueChanged(Dropdown change){

		indexOfSelectedValue = change.value; 

		CurrentPrefabSelected = menuOptions[indexOfSelectedValue].text.ToString(); 
		Debug.Log("dropdown changed to: " + CurrentPrefabSelected); 


	///THIS SETS THE BUTTON TO THE TEXT OF THE DROPDOWN 
		otherButton.yourButton.GetComponent<Button>().GetComponentInChildren<Text>().text = "Place: " + CurrentPrefabSelected; 

	}
	 
	// Update is called once per frame
	void Update () {
		CurrentDropdownValue = CurrentPrefabSelected; 
	}
}
