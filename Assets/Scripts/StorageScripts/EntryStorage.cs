using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryStorage : BuildingStorage
{
	public List<Resource> _allowedResources;
	
	public void SetAllowedResources(List<Resource> resources)
	{
		_allowedResources = resources;
	}
	
	protected void OnTriggerStay(Collider other)
	{
		if(other.tag.Equals("Player") && GameManager.Instance.PlayerController.IsStanding())
		{
			if(!IsFull() && !GameManager.Instance.PlayerInventory.IsEmpty() && !GameManager.Instance.IsTransferring)
			{
				Resource resource = GameManager.Instance.PlayerInventory.GetLastResourceFromList(_allowedResources);
				if(resource != null)
				{
					resource.transform.SetParent(null);
					GameManager.Instance.PlayerInventory.Remove(resource);
					GameManager.Instance.PlayerInventory.UpdateStock();
					GameManager.Instance.IsTransferring = true;
					Add(resource);
					StartCoroutine(GameManager.Instance.StopTransferring(resource));
					
				}
			}
		}
	}
}
