using System.Collections.Generic;
using BuildingScripts;
using UnityEngine;

namespace StorageScripts
{
	public class EnterStorage : BuildingStorage
	{
		private List<Resource> _allowedResources;
	
		public void RemoveFromPlacesAndLerp(Resource resource, Transform position)
		{
			foreach(StoragePlace place in storagePlaces)
			{
				if(place.Contains(resource))
				{
					place.Remove(position);
					break;
				}
			}
		}
	
		public void SetAllowedResources(List<Resource> resources)
		{
			_allowedResources = resources;
		}
	
		protected override void OnTriggerStay(Collider other)
		{
			if(other.tag.Equals("Player") && GameManager.player.IsStanding())
			{
				if(!IsFull() && !GameManager.playerStock.IsEmpty() && !GameManager.transferring)
				{
					Resource resource = GameManager.playerStock.GetLastResourseFromAllowed(_allowedResources);
					if(resource != null)
					{
						resource.transform.SetParent(null);
						GameManager.transferring = true;
						GameManager.playerStock.TransferResource(this, resource);
						StartCoroutine(StopTransferring(resource));
					}
				}
			}
		}
	}
}
