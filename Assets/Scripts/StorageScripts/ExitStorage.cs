using BuildingScripts;
using UnityEngine;

namespace StorageScripts
{
	public class ExitStorage : BuildingStorage
	{
		protected override void OnTriggerStay(Collider other)
		{
			if(other.tag.Equals("Player") && GameManager.player.IsStanding())
			{
				if(resourcesStored.Count > 0 && !GameManager.playerStock.IsFull() && !GameManager.transferring)
				{
					Resource resource = resourcesStored[resourcesStored.Count-1];
					resource.transform.SetParent(null);
					GameManager.transferring = true;
					RemoveFromPlaces(resource);
					TransferResource(GameManager.playerStock, resource);
					StartCoroutine(StopTransferring(resource));
				}
			}
		}
	}
}
