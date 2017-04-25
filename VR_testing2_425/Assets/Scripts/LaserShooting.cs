using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooting: MonoBehaviour {

	GameObject hitedObject;
	public GameObject Puzzle1;
	public GameObject Puzzle2;
	public GameObject Puzzle3;
	// 1
	public Transform cameraRigTransform; 
	// 2
	public GameObject teleportReticlePrefab;
	// 3
	private GameObject reticle;
	// 4
	private Transform teleportReticleTransform; 
	// 5
	public Transform headTransform; 
	// 6
	public Vector3 teleportReticleOffset; 
	// 7
	public LayerMask teleportMask; 
	// 8
	private bool shouldTeleport;


	private SteamVR_TrackedObject trackedObj;
	// 1
	public GameObject laserPrefab;
	// 2
	private GameObject laser;
	// 3
	private Transform laserTransform;
	// 4
	private Vector3 hitPoint;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	private void ShowLaser(RaycastHit hit)
	{
		// 1
		laser.SetActive(true);
		// 2
		laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
		// 3
		laserTransform.LookAt(hitPoint); 
		// 4
		laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
			hit.distance);
	}

	void Start () 
	{// 1
		laser = Instantiate(laserPrefab);
		// 2
		laserTransform = laser.transform;
		// 1
		reticle = Instantiate(teleportReticlePrefab);
		// 2
		teleportReticleTransform = reticle.transform;

	}

	void Update () 
	{
		// 1
		if (Controller.GetPress(SteamVR_Controller.ButtonMask.Grip))
		{
			RaycastHit hit;

			// 2
			if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, teleportMask))
			{
				hitPoint = hit.point;
				ShowLaser(hit);
				if (hit.collider != null) 
				{
				hit.transform.gameObject.SetActive (false);
				Debug.Log (hit.transform.gameObject.name);
				//Destroy (hit.transform.gameObject);
				
				}
			}
		}
		else // 3
		{
			laser.SetActive(false);
			reticle.SetActive(false);
		}

		//check if puzzle piece be shooted and active the UI info
		if (Puzzle1.active == false &&Puzzle2.active == false && Puzzle3.active == false )
		{


		}
	}


	private void Teleport() //action during teleporting 
	{
		// 1
		shouldTeleport = false; //shouln't teleport during teleporting
		// 2
		reticle.SetActive(false); //no reticle mark/sign
		// 3
		Vector3 difference = cameraRigTransform.position - headTransform.position;
		// 4
		difference.y = 0;
		// 5
		cameraRigTransform.position = hitPoint + difference;
	}

}
