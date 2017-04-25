using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// put this script on the thing to be looked at
// do not put on the player or camera!!
public class GetTimeScript : MonoBehaviour {

	public Text timeInfoText;
	public Text DataTitle;
	public Text VrText;

	public float DunkinDonuts_timeLooked = 0f;   //1
	public float      Google_timeLooked = 0f;   //2
	public float    CokeCola_timeLooked = 0f;	//3
	public float   McDonalds_timeLooked = 0f;	//4
	public float         Bus_timeLooked = 0f;	//5
	public float      Chanel_timeLooked = 0f;	//6sss
	public float  BurgerKing_timeLooked = 0f;	//7
	public float         Mms_timeLooked = 0f;	//8
	public float     TMobile_timeLooked = 0f;	//9
	public float       Pizza_timeLooked = 0f;	//10
	public float   Starbucks_timeLooked = 0f;	//11
	public float         AMC_timeLooked = 0f;	//12

	string hitedObjectName;

	string lookingTime_DunkinDonuts; //1
	string lookingTime_Google;		//2
	string lookingTime_CokeCola;	//3
	string lookingTime_McDonalds;	//4
	//string lookingTime_Bus;			//5
	string lookingTime_Chanel;		//6
	string lookingTime_BurgerKing;	//7
	string lookingTime_Mms;	        //8
	string lookingTime_TMobile;	   	//9
	string lookingTime_Pizza;		//10
	string lookingTime_Starbucks;	//11
	string lookingTime_AMC;	 		//12


	// UI setting
	void SetTextList()
	{
		timeInfoText.text = "Timing List: " + "\n"
			+ lookingTime_DunkinDonuts + "\n"
			+ lookingTime_Google + "\n"
			+ lookingTime_CokeCola + "\n"
			+ lookingTime_McDonalds + "\n"
		//	+ lookingTime_Bus +" \n"
			+ lookingTime_Chanel + "\n"
			+ lookingTime_BurgerKing + "\n"
			+ lookingTime_Mms + "\n"
			+ lookingTime_TMobile + "\n"
			+ lookingTime_Pizza +" \n"
			+ lookingTime_Starbucks + "\n"
			+ lookingTime_AMC + "\n";
		
		VrText.text =  "Watched On Disturbed Info: " + "\n"
			+ lookingTime_DunkinDonuts + "\n"
			+ lookingTime_Google + "\n"
			+ lookingTime_CokeCola + "\n"
			+ lookingTime_McDonalds + "\n"
		//	+ lookingTime_Bus +" \n"
			+ lookingTime_Chanel + "\n"
			+ lookingTime_BurgerKing + "\n"
			+ lookingTime_Mms + "\n"
			+ lookingTime_TMobile + "\n"
			+ lookingTime_Pizza +" \n"
			+ lookingTime_Starbucks + "\n"
			+ lookingTime_AMC + "\n";
	}

	void Start ()
	{
		SetTextList ();	
	}


	void Update () 
	{
		// 1. calculate the Raycast origin and direction
		Ray ray = new Ray( Camera.main.transform.position, Camera.main.transform.forward );
		// 2. setup our RaycastHit riable, reserve memory for it
		RaycastHit myRayHit = new RaycastHit();  // ji cheng gai function's shu xing
		Debug.DrawRay( ray.origin, ray.direction * 50f, Color.yellow );
	//	SetTextList ();	

		if ( Physics.Raycast( ray, out myRayHit, 50f ) ) 
		{
			
			hitedObjectName = myRayHit.collider.gameObject.name;
		//	Debug.Log (hitedObjectName);

			// seperated itmes from here 
			//1
			if(hitedObjectName == "DunkinDonuts")
			{
				DunkinDonuts_timeLooked += Time.deltaTime;
				DunkinDonuts_timeLooked = Mathf.Round (DunkinDonuts_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (DunkinDonuts_timeLooked);
				lookingTime_DunkinDonuts = hitedObjectName + " be looked: " + DunkinDonuts_timeLooked;
				//Debug.Log (lookingTime_Wall_1);
				SetTextList ();
			}

			//2
			if(hitedObjectName == "Google")
			{
				Google_timeLooked += Time.deltaTime;
				Google_timeLooked = Mathf.Round (Google_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (Google_timeLooked);
				lookingTime_Google = hitedObjectName + " be looked: " + Google_timeLooked;
				//Debug.Log (lookingTime_Wall_2);
				SetTextList ();
			}
			//3
			if(hitedObjectName == "CokeCola")
			{
				CokeCola_timeLooked += Time.deltaTime;
				CokeCola_timeLooked = Mathf.Round (CokeCola_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (CokeCola_timeLooked);
				lookingTime_CokeCola = hitedObjectName + " be looked: " + CokeCola_timeLooked;
			//	Debug.Log (lookingTime_Wall_3);
				SetTextList ();
			}
			//4
			if(hitedObjectName == "McDonalds")
			{
				McDonalds_timeLooked += Time.deltaTime;
				McDonalds_timeLooked = Mathf.Round (McDonalds_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (McDonalds_timeLooked);
				lookingTime_McDonalds = hitedObjectName + " be looked: " + McDonalds_timeLooked;
			//	Debug.Log (lookingTime_Wall_4);
				SetTextList ();
			}

		/*	//5
			if(hitedObjectName == "Bus")
			{
				Bus_timeLooked += Time.deltaTime;
				lookingTime_Bus = hitedObjectName + " be looked: " + Bus_timeLooked;
			//	Debug.Log (lookingTime_Ball_1);
				SetTextList ();
			}  */

			//6
			if(hitedObjectName == "Chanel")
			{
				Chanel_timeLooked += Time.deltaTime;
				Chanel_timeLooked = Mathf.Round (Chanel_timeLooked * 100f) / 100f;
				lookingTime_Chanel = hitedObjectName + " be looked: " + Chanel_timeLooked;
			//	Debug.Log (lookingTime_Ball_2);
				SetTextList ();
			}

			//7
			if(hitedObjectName == "BurgerKing")
			{
				BurgerKing_timeLooked += Time.deltaTime;
				BurgerKing_timeLooked = Mathf.Round (BurgerKing_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (BurgerKing_timeLooked);
				lookingTime_BurgerKing = hitedObjectName + " be looked: " + BurgerKing_timeLooked;
			//	Debug.Log (lookingTime_Ball_3);
				SetTextList ();
			}

			//8
			if(hitedObjectName == "Mms")
			{
				Mms_timeLooked += Time.deltaTime;
				Mms_timeLooked = Mathf.Round (Mms_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (Mms_timeLooked);
				lookingTime_Mms = hitedObjectName + " be looked: " + Mms_timeLooked;
			//	Debug.Log (lookingTime_Ball_4);
				SetTextList ();
			}

			//9
			if(hitedObjectName == "TMobile")
			{
				TMobile_timeLooked += Time.deltaTime;
				TMobile_timeLooked = Mathf.Round (TMobile_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (TMobile_timeLooked);
				lookingTime_TMobile = hitedObjectName + " be looked: " + TMobile_timeLooked;
				//	Debug.Log (lookingTime_Ball_4);
				SetTextList ();
			}

			//10
			if(hitedObjectName == "Pizza")
			{
				Pizza_timeLooked += Time.deltaTime;
				Pizza_timeLooked = Mathf.Round (Pizza_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (Pizza_timeLooked);
				lookingTime_Pizza = hitedObjectName + " be looked: " + Pizza_timeLooked;
				//	Debug.Log (lookingTime_Ball_4);
				SetTextList ();
			}

			//11
			if(hitedObjectName == "Starbucks")
			{
				Starbucks_timeLooked += Time.deltaTime;
				Starbucks_timeLooked = Mathf.Round (Starbucks_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (Starbucks_timeLooked);
				lookingTime_Starbucks = hitedObjectName + " be looked: " + Starbucks_timeLooked;
				//	Debug.Log (lookingTime_Ball_4);
				SetTextList ();
			}

			//12
			if(hitedObjectName == "AMC")
			{
				AMC_timeLooked += Time.deltaTime;
				AMC_timeLooked = Mathf.Round (AMC_timeLooked * 100f) / 100f;
				Mathf.RoundToInt (AMC_timeLooked);
				lookingTime_AMC = hitedObjectName + " be looked: " + AMC_timeLooked;
				//	Debug.Log (lookingTime_Ball_4);
				SetTextList ();
			}


		} 

	}// update‘s bracket
		

} // class' bracket
