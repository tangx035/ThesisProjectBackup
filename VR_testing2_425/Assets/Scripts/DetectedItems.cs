using UnityEngine;
using System.Collections;
using System; //This allows the IComparable Interface

//This is the class you will be storing
//in the different collections. In order to use
//a collection's Sort() method, this class needs to
//implement the IComparable interface.
public class DetectedItems : IComparable<DetectedItems>
{
	public GameObject name;
	public int time;

	public DetectedItems(GameObject newName, int newTime)
	{
		name = newName;
		time = newTime;
	}

	//This method is required by the IComparable
	//interface. 
	public int CompareTo(DetectedItems other)
	{
		if(other == null)
		{
			return 1;
		}

		//Return the difference in power.
		return time - other.time;
	}
}