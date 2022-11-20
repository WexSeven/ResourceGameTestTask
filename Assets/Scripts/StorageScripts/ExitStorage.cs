using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStorage : BuildingStorage
{
	protected void OnTriggerStay(Collider other)
	{
		if(other.tag.Equals("Player") && GameManager.Instance.PlayerController.IsStanding())
		{
			if(!IsEmpty() && !GameManager.Instance.PlayerInventory.IsFull() && !GameManager.Instance.PlayerInventory.IsTransferring)
			{
				Resource resource = StoredResources[StoredResources.Count-1];
				Remove(resource);
				RemoveFromPlaces(resource);
				GameManager.Instance.PlayerInventory.Add(resource);
				GameManager.Instance.PlayerInventory.StartTransferring(resource);
			}
		}
	}
}
