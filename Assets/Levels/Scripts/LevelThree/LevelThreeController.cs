using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelThreeController : MonoBehaviour {
	
	//States
	public bool R1Started;
	public bool R1Inprogress;
	public bool R1Completed;
	
	public bool R2Started;
	public bool R2Inprogress;
	public bool R2Completed;
	
	public bool R3Started;
	public bool R3Inprogress;
	public bool R3Completed;
	
	public bool R4Started;
	public bool R4Inprogress;
	public bool R4Completed;
	
	public bool R5Started;
	public bool R5Inprogress;
	public bool R5Completed;

	public bool FinaleStarted;
	public bool LightUpBonfire;
	public bool FinaleCompleted;
	public bool AllDone;
	
	//Route One, Red
	public List<GameObject> TorchesFlameR1 = new List<GameObject>();
	public GameObject SpecialTorchFlameR1;
	public GameObject SpecialTorchR1;
	public GameObject RockR1;
	public GameObject ClimbUpR1;
	public GameObject CannonShooterR1;
	public GameObject GeneratorR1;
	public List<GameObject> RngPosR1 = new List<GameObject>();
	
	//Route Two, Blue
	public List<GameObject> TorchesFlameR2 = new List<GameObject>();
	public GameObject SpecialTorchFlameR2;
	public GameObject SpecialTorchR2;
	public GameObject RockR2;
	public GameObject ClimbUpR2;
	public GameObject CannonShooterR2;
	public GameObject GeneratorR2;
	public List<GameObject> RngPosR2 = new List<GameObject>();
	
	//Route Three, Green
	public List<GameObject> TorchesFlameR3 = new List<GameObject>();
	public GameObject SpecialTorchFlameR3;
	public GameObject SpecialTorchR3;
	public GameObject RockR3;
	public GameObject ClimbUpR3;
	public GameObject CannonShooterR3;
	public GameObject GeneratorR3;
	public List<GameObject> RngPosR3 = new List<GameObject>();
	
	//Route Four, Yellow
	public List<GameObject> TorchesFlameR4 = new List<GameObject>();
	public GameObject SpecialTorchFlameR4;
	public GameObject SpecialTorchR4;
	public GameObject RockR4;
	public GameObject ClimbUpR4;
	public GameObject CannonShooterR4;
	public GameObject GeneratorR4;
	public List<GameObject> RngPosR4 = new List<GameObject>();
	
	//Route Five, Purple
	public List<GameObject> TorchesFlameR5 = new List<GameObject>();
	public GameObject SpecialTorchFlameR5;
	public GameObject SpecialTorchR5;
	public GameObject RockR5;
	public GameObject ClimbUpR5;
	public GameObject CannonShooterR5;
	public GameObject GeneratorR5;
	public List<GameObject> RngPosR5 = new List<GameObject>();
	public GameObject MemoryFragmentBonfire;
	
	//Finale
	public GameObject VerticalShooters;
	public GameObject RouteEntrances;
	public GameObject Fences;
	public GameObject Bonfire;
	public GameObject MemoryFragmentOmen;
	
	//Player's torch
	public GameObject TorchInHand;
	
	//Torch prefab
	public GameObject TorchPrefab;

	// Use this for initialization
	void Start () {
		if (R1Completed || R2Completed || R3Completed || R4Completed || R5Completed)
		{
			if (R1Completed)
			{
				StartRoute(1, RockR1);
				ProgressRoute(1);
				CompleteRoute(1);
			}
			if (R2Completed)
			{
				StartRoute(2, RockR2);
				ProgressRoute(2);
				CompleteRoute(2);
			}
			if (R3Completed)
			{
				StartRoute(3, RockR3);
				ProgressRoute(3);
				CompleteRoute(3);
			}
			if (R4Completed)
			{
				StartRoute(4, RockR4);
				ProgressRoute(4);
				CompleteRoute(4);
			}
			if (R5Completed)
			{
				StartRoute(5, RockR5);
				ProgressRoute(5);
				CompleteRoute(5);
			}
		}
		else
		{
			foreach (GameObject flame in TorchesFlameR1)
			{
				flame.SetActive(false);
			}
			foreach (GameObject flame in TorchesFlameR2)
			{
				flame.SetActive(false);
			}
			foreach (GameObject flame in TorchesFlameR3)
			{
				flame.SetActive(false);
			}
			foreach (GameObject flame in TorchesFlameR4)
			{
				flame.SetActive(false);
			}
			foreach (GameObject flame in TorchesFlameR5)
			{
				flame.SetActive(false);
			}
			SpecialTorchFlameR1.SetActive(false);
			SpecialTorchFlameR2.SetActive(false);
			SpecialTorchFlameR3.SetActive(false);
			SpecialTorchFlameR4.SetActive(false);
			SpecialTorchFlameR5.SetActive(false);
			SpecialTorchR1.SetActive(false);
			SpecialTorchR2.SetActive(false);
			SpecialTorchR3.SetActive(false);
			SpecialTorchR4.SetActive(false);
			SpecialTorchR5.SetActive(false);
			ClimbUpR1.SetActive(false);
			ClimbUpR2.SetActive(false);
			ClimbUpR3.SetActive(false);
			ClimbUpR4.SetActive(false);
			ClimbUpR5.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (R5Completed && !FinaleStarted)
		{
			VerticalShooters.SetActive(true);
			RouteEntrances.SetActive(true);
			//Fences.SetActive(true); No more fence.
			//MemoryFragmentBonfire.SetActive(true);
			FinaleStarted = true;
		}
		else if (FinaleStarted && !FinaleCompleted && AllDone)
		{
			Bonfire.SetActive(true);
			MemoryFragmentOmen.SetActive(true);
			FinaleCompleted = true;
		}
	}

	public void StartRoute(int routeNumber, GameObject caller)
	{
		if (routeNumber == 1)
		{
			R1Started = true;
			SpecialTorchR1.SetActive(true);
			Destroy(caller);
		}
		else if (routeNumber == 2)
		{
			if (R1Completed)
			{
				R2Started = true;
				SpecialTorchR2.SetActive(true);
				Destroy(caller);
			}
		}
		else if (routeNumber == 3)
		{
			if (R1Completed && R2Completed)
			{
				R3Started = true;
				SpecialTorchR3.SetActive(true);
				Destroy(caller);
			}
		}
		else if (routeNumber == 4)
		{
			if (R1Completed && R2Completed && R3Completed)
			{
				R4Started = true;
				SpecialTorchR4.SetActive(true);
				Destroy(caller);
			}
		}
		else if (routeNumber == 5)
		{
			if (R1Completed && R2Completed && R3Completed && R4Completed)
			{
				R5Started = true;
				SpecialTorchR5.SetActive(true);
				Destroy(caller);
			}
		}
	}
	
	public void ProgressRoute(int routeNumber)
	{
		if (routeNumber == 1)
		{
			R1Inprogress = true;
			SpecialTorchFlameR1.SetActive(true);
			ClimbUpR1.SetActive(true);
			TorchInHand.SetActive(false);
		}
		else if (routeNumber == 2)
		{
			R2Inprogress = true;
			SpecialTorchFlameR2.SetActive(true);
			ClimbUpR2.SetActive(true);
			TorchInHand.SetActive(false);
		}
		else if (routeNumber == 3)
		{
			R3Inprogress = true;
			SpecialTorchFlameR3.SetActive(true);
			ClimbUpR3.SetActive(true);
			TorchInHand.SetActive(false);
		}
		else if (routeNumber == 4)
		{
			R4Inprogress = true;
			SpecialTorchFlameR4.SetActive(true);
			ClimbUpR4.SetActive(true);
			TorchInHand.SetActive(false);
		}
		else if (routeNumber == 5)
		{
			R5Inprogress = true;
			SpecialTorchFlameR5.SetActive(true);
			ClimbUpR5.SetActive(true);
			TorchInHand.SetActive(false);
		}
	}
	
	public void CompleteRoute(int routeNumber)
	{
		if (routeNumber == 1)
		{
			GeneratorR1.SetActive(true);
			CannonShooterR1.SetActive(true);
			foreach (GameObject flame in TorchesFlameR1)
			{
				flame.SetActive(true);
			}
			int pos = Random.Range(0, 3);
			RngPosR1[pos].SetActive(false);
			GameObject obj = (GameObject) Instantiate(TorchPrefab, RngPosR1[pos].transform.position, RngPosR1[pos].transform.rotation);
			obj.AddComponent<Rigidbody>().isKinematic = true;
			obj.AddComponent<BoxCollider>().isTrigger = true;
			obj.GetComponent<Torchelight>().MaxLightIntensity = 20;
			obj.GetComponent<Torchelight>().IntensityLight = 18;
			obj.AddComponent<PickUpTorch>();
			Debug.Log("RNG instantiated at position " + obj.transform.position);
			R1Completed = true;
		}
		else if (routeNumber == 2)
		{
			GeneratorR2.SetActive(true);
			CannonShooterR2.SetActive(true);
			foreach (GameObject flame in TorchesFlameR2)
			{
				flame.SetActive(true);
			}
			int pos = Random.Range(0, 3);
			RngPosR2[pos].SetActive(false);
			GameObject obj = (GameObject) Instantiate(TorchPrefab, RngPosR2[pos].transform.position, RngPosR2[pos].transform.rotation);
			obj.AddComponent<Rigidbody>().isKinematic = true;
			obj.AddComponent<BoxCollider>().isTrigger = true;
			obj.GetComponent<Torchelight>().MaxLightIntensity = 20;
			obj.GetComponent<Torchelight>().IntensityLight = 18;
			obj.AddComponent<PickUpTorch>();
			Debug.Log("RNG instantiated at position " + obj.transform.position);
			R2Completed = true;
		}
		else if (routeNumber == 3)
		{
			GeneratorR3.SetActive(true);
			CannonShooterR3.SetActive(true);
			foreach (GameObject flame in TorchesFlameR3)
			{
				flame.SetActive(true);
			}
			int pos = Random.Range(0, 3);
			RngPosR3[pos].SetActive(false);
			GameObject obj = (GameObject) Instantiate(TorchPrefab, RngPosR3[pos].transform.position, RngPosR3[pos].transform.rotation);
			obj.AddComponent<Rigidbody>().isKinematic = true;
			obj.AddComponent<BoxCollider>().isTrigger = true;
			obj.GetComponent<Torchelight>().MaxLightIntensity = 20;
			obj.GetComponent<Torchelight>().IntensityLight = 18;
			obj.AddComponent<PickUpTorch>();
			Debug.Log("RNG instantiated at position " + obj.transform.position);
			R3Completed = true;
		}
		else if (routeNumber == 4)
		{
			GeneratorR4.SetActive(true);
			CannonShooterR4.SetActive(true);
			foreach (GameObject flame in TorchesFlameR4)
			{
				flame.SetActive(true);
			}
			int pos = Random.Range(0, 3);
			RngPosR4[pos].SetActive(false);
			GameObject obj = (GameObject) Instantiate(TorchPrefab, RngPosR4[pos].transform.position, RngPosR4[pos].transform.rotation);
			obj.AddComponent<Rigidbody>().isKinematic = true;
			obj.AddComponent<BoxCollider>().isTrigger = true;
			obj.GetComponent<Torchelight>().MaxLightIntensity = 20;
			obj.GetComponent<Torchelight>().IntensityLight = 18;
			obj.AddComponent<PickUpTorch>();
			Debug.Log("RNG instantiated at position " + obj.transform.position);
			R4Completed = true;
		}
		else if (routeNumber == 5)
		{
			GeneratorR5.SetActive(true);
			CannonShooterR5.SetActive(true);
			foreach (GameObject flame in TorchesFlameR5)
			{
				flame.SetActive(true);
			}
			int pos = Random.Range(0, 3);
			RngPosR5[pos].SetActive(false);
			GameObject obj = (GameObject) Instantiate(TorchPrefab, RngPosR5[pos].transform.position, RngPosR5[pos].transform.rotation);
			obj.AddComponent<Rigidbody>().isKinematic = true;
			obj.AddComponent<BoxCollider>().isTrigger = true;
			obj.GetComponent<Torchelight>().MaxLightIntensity = 20;
			obj.GetComponent<Torchelight>().IntensityLight = 18;
			obj.AddComponent<PickUpTorch>();
			Debug.Log("RNG instantiated at position " + obj.transform.position);
			R5Completed = true;
		}
	}
}
