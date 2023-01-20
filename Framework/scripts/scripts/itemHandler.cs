using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHandler : MonoBehaviour
{
	public GameObject[] slots;
	public GameObject prefabSlot;
	public GameObject inventory;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		for (int i = 1; i <= 30; i++) {
			slots[slots.Length] = Instantiate(prefabSlot, inventory.transform);
		}
	}
	
}
