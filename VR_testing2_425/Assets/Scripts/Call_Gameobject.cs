
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System;

public class Call_Gameobject : MonoBehaviour {


	//  public this GameObject in the inspector, for later on putting the object which holding the script need to access on it
	//	public GameObject wall_1;
	public GameObject accessScriptObject_Dunkin;
	// "getTime" need to be the script's excauate name that need to access.
	// "SecondScriptToAccess" is the variable for holding the component/code accessed from other script.
	private GetTimeScript SecondScriptToAccess; 
	//public prefabs
	public GameObject Pf_DunkinDonuts;
	public GameObject Pf_Google;
	public GameObject Pf_CokeCola;
	public GameObject Pf_McDonalds;
	public GameObject Pf_Chanel;
	public GameObject Pf_BurgerKing;
	public GameObject Pf_Mms;
	public GameObject Pf_TMobile;
	public GameObject Pf_Pizza;
	public GameObject Pf_Starbucks;
	public GameObject Pf_AMC;

	public GameObject prefabLoad;
	public GameObject Hold_Logo;
	public GameObject Canvas_VR;


	private int     donuts_timeBeLooked;
	private int     google_timeBeLooked;
	private int   cokecola_timeBeLooked;
	private int  mcDonalds_timeBeLooked;
	private int     chanel_timeBeLooked;
	private int burgerKing_timeBeLooked;
	private int        mms_timeBeLooked;
	private int    tMobile_timeBeLooked;
	private int      pizza_timeBeLooked;
	private int  starbucks_timeBeLooked;
	private int        amc_timeBeLooked;

	float timeCounting;
	List<DetectedItems> itemsAttribute = new List<DetectedItems> ();
	public	GameObject[] prefabObjects = new GameObject[11];
	public GameObject[] convertIntoArray = new GameObject[11];
	private bool PrintOnce;
	private bool ifCountingDown = false;
	public Text countDown;

	void CountDownText(){
		countDown.GetComponent<Text>().enabled = true;
		timeCounting -= Time.deltaTime;
		countDown.text = "Time to skip: "+ (int)timeCounting;
	}
	void Start () 
	{
		//data getting
		SecondScriptToAccess = accessScriptObject_Dunkin.GetComponent<GetTimeScript> ();
		IntoInt ();
		ItemsList ();
		ifCountingDown = false;
		timeCounting = 5;

		prefabObjects[0] = Pf_DunkinDonuts;
		prefabObjects[1] = Pf_Google;
		prefabObjects[2] = Pf_CokeCola;
		prefabObjects[3] = Pf_McDonalds;
		prefabObjects[4] = Pf_Chanel;
		prefabObjects[5] = Pf_BurgerKing;
		prefabObjects[6] = Pf_Mms;
		prefabObjects[7] = Pf_TMobile;
		prefabObjects[8] = Pf_Pizza;
		prefabObjects[9] = Pf_Starbucks;
		prefabObjects[10] = Pf_AMC;
	}

	void IntoInt()
	{
		donuts_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.DunkinDonuts_timeLooked); 
		google_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.Google_timeLooked); 
		cokecola_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.CokeCola_timeLooked); 
		mcDonalds_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.McDonalds_timeLooked); 
	//	ball_1_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.Bus_timeLooked); 
		chanel_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.Chanel_timeLooked); 
		burgerKing_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.BurgerKing_timeLooked); 
		mms_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.Mms_timeLooked); 
		tMobile_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.TMobile_timeLooked); 
		pizza_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.Pizza_timeLooked); 
		starbucks_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.Starbucks_timeLooked); 
		amc_timeBeLooked= Mathf.RoundToInt(SecondScriptToAccess.AMC_timeLooked); 
	}

	void ItemsList()
	{
		itemsAttribute.Add ( new DetectedItems(Pf_DunkinDonuts, donuts_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_Google,       google_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_CokeCola,   cokecola_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_McDonalds, mcDonalds_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_Chanel,       chanel_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_BurgerKing,burgerKing_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_Mms,             mms_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_TMobile,     tMobile_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_Pizza,         pizza_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_Starbucks, starbucks_timeBeLooked));
		itemsAttribute.Add ( new DetectedItems(Pf_AMC,             amc_timeBeLooked));

	}

	void PrintItemsTime()
	{
		foreach (DetectedItems eachItems in itemsAttribute) 
		{
			print (eachItems.name + ": " + eachItems.time);
		}
		//itemsAttribute.Clear();
	}


	void Update ()
	{
		//call IntoInt function to change all float numbers into integer
		IntoInt ();
		// add items into list with name and int time number init
	//	ItemsList (); 
		//sort list "items" according to comparer which called from "DetectedItems.cs"\
		PrintOnce = false;
		countDown.GetComponent<Text>().enabled = false;

		if (Input.GetKeyDown (KeyCode.B)) 
		{
			ItemsList ();
			itemsAttribute.Sort ();
			itemsAttribute.Reverse ();
			PrintOnce = true;
			if(itemsAttribute.Count > 12)
			{
				itemsAttribute.Clear ();
				//ItemsList (); 
			}
		}

		if (PrintOnce == true) 
		{
			PrintItemsTime (); //print out wateched int times in concole
			PrintOnce = false;
	//		itemsAttribute.Clear ();
		}

		if (Input.GetKeyDown (KeyCode.C)) 
		{
			itemsAttribute.Clear ();
		}
		if (Input.GetKeyDown (KeyCode.L)) 
		{
		//	Print itemsAttribute.();
			print(itemsAttribute.Count);
		}
		//GameObject cloneObject = new GameObject();


		//instantiate all objects by two for loops
//		if (Input.GetKeyDown (KeyCode.A)) 
//		{   ifCountingDown = true;
//			for (int i = 0; i < 11; i++) {
//			for (int j = 0; j < prefabObjects.Length; j++) { 
//					if (prefabObjects[j] == itemsAttribute [i].name) 
//					{
//						Instantiate (prefabObjects[j] );
//
//				}
//				}
//			}
//		}


//		if (Input.GetKeyDown (KeyCode.Z)) 
//		{
//		//  Instantiate (prefabObjects[0]);
//	//		prefabObjects[0].transform.parent = test.transform;
//			prefabLoad = Instantiate (prefabObjects[0]);
//		//	prefabLoad.transform.parent = hold_logo.transform;
//			prefabLoad.transform.SetParent (hold_logo.transform, false);
//	
//		}
//
		if (Input.GetKeyDown (KeyCode.S)) 
		{			
			ifCountingDown = true;
			for (int i = 0; i < 11; i++) 
			{
				if (prefabObjects [i]== itemsAttribute [0].name) 
				{
					prefabLoad = Instantiate (prefabObjects [i]);
					prefabLoad.transform.SetParent (Canvas_VR.transform, false);
				}
			}
			timeCounting = 5;
			Destroy (prefabLoad, 5);
		}

		if (Input.GetKeyDown (KeyCode.D)) 
		{
			ifCountingDown = true;
			for (int i = 0; i < 11; i++) {
				if (prefabObjects [i]== itemsAttribute [1].name) {
					prefabLoad = Instantiate (prefabObjects [i]);
					prefabLoad.transform.SetParent (Canvas_VR.transform, false);
				}

			}
			timeCounting = 5;
			Destroy (prefabLoad, 5);
		}
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			ifCountingDown = true;
			for (int i = 0; i < 11; i++) {
				if (prefabObjects [i]== itemsAttribute [2].name) {
					prefabLoad = Instantiate (prefabObjects [i]);
					prefabLoad.transform.SetParent (Canvas_VR.transform, false);
				}

			}
			timeCounting = 5;
			Destroy (prefabLoad, 5);
		}

		if (Input.GetKeyDown (KeyCode.G)) 
		{
			ifCountingDown = true;
			for (int i = 0; i < 11; i++) {
				if (prefabObjects [i]== itemsAttribute [3].name) {
					prefabLoad = Instantiate (prefabObjects [i]);
					prefabLoad.transform.SetParent (Canvas_VR.transform, false);
				}

			}
			timeCounting = 5;
			Destroy (prefabLoad, 5);
		}
		if (Input.GetKeyDown (KeyCode.H)) 
		{
			ifCountingDown = true;
			for (int i = 0; i < 11; i++) {
				if (prefabObjects [i]== itemsAttribute [4].name) {
					prefabLoad = Instantiate (prefabObjects [i]);
					prefabLoad.transform.SetParent (Canvas_VR.transform, false);
				}

			}
			timeCounting = 5;
			Destroy (prefabLoad, 5);
		}


		if (Input.GetKeyDown (KeyCode.J)) 
		{
			ifCountingDown = true;
			for (int i = 0; i < 11; i++) {
				if (prefabObjects [i]== itemsAttribute [5].name) {
					prefabLoad = Instantiate (prefabObjects [i]);
					prefabLoad.transform.SetParent (Canvas_VR.transform, false);
				}

			}
			timeCounting = 5;
			Destroy (prefabLoad, 5);
		}
		if (Input.GetKeyDown (KeyCode.K)) 
		{
			ifCountingDown = true;
			for (int i = 0; i < 11; i++) {
				if (prefabObjects [i]== itemsAttribute [5].name) {
					prefabLoad = Instantiate (prefabObjects [i]);
					prefabLoad.transform.SetParent (Canvas_VR.transform, false);
				}

			}
			timeCounting = 5;
			Destroy (prefabLoad, 5);
		}
		//////////////////
		if (ifCountingDown == true)
		{

			CountDownText ();
			if (timeCounting <0)
			{
				countDown.GetComponent<Text>().enabled = false;
				ifCountingDown = false;
			}
		}
	}
		

}

// GameObject.Find("DoubleRockets").GetComponent("gunscript");
