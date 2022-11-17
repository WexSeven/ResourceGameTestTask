using System.Collections;
using StorageScripts;
using UnityEngine;

namespace BuildingScripts
{
	public abstract class BuildingStorage : Storage
	{
		protected StoragePlace[] storagePlaces;
	
		protected virtual void Awake()
		{
			storagePlaces = new StoragePlace[maxStorage];
			for(int i = 0; i < storagePlaces.Length; i++)
			{
				storagePlaces[i] = transform.GetChild(i).GetComponent<StoragePlace>();
			}
		}
	
		public override void Add(Resource resource)
		{
			base.Add(resource);
			AddToPlaces(resource);
		}

		private void AddToPlaces(Resource resource)
		{
			foreach(StoragePlace place in storagePlaces)
			{
				if(place.IsEmpty())
				{
					place.Add(resource);
					break;
				}
			}
		}

		protected void RemoveFromPlaces(Resource resource)
		{
			foreach(StoragePlace place in storagePlaces)
			{
				if(place.Contains(resource))
				{
					place.Clear();
					break;
				}
			}
		}
	
		protected abstract void OnTriggerStay(Collider other);
	
		protected IEnumerator StopTransferring(Resource resource)
		{
			yield return new WaitUntil(() => !resource.moving);
			GameManager.transferring = false;
		}
	}
}
