using System.Collections.Generic;
using UnityEngine;

namespace StorageScripts
{
	public abstract class Storage : MonoBehaviour
	{
		public int maxStorage;
		public List<Resource> resourcesStored;
	
		public virtual void Add(Resource resource)
		{
			resourcesStored.Add(resource);
		}
	
		public void Remove(Resource resource)
		{
			resourcesStored.Remove(resource);
		}
	
		public bool IsEmpty()
		{
			if(resourcesStored.Count == 0)
			{
				return true;
			}
			return false;
		}
	
		public bool IsFull()
		{
			if(resourcesStored.Count == maxStorage)
			{
				return true;
			}
			return false;
		}
	
		public Resource GetLastResource()
		{
			if(resourcesStored.Count > 0)
			{
				return resourcesStored[resourcesStored.Count-1];
			}
			return null;
		}
	
		public Resource GetLastResourceOfType(Resource resource)
		{
			for(int i = resourcesStored.Count-1; i >= 0; i--)
			{
				if(resourcesStored[i].title.Equals(resource.title))
				{
					return resourcesStored[i];
				}
			}
			return null;
		}
	
		public virtual void TransferResource(Storage storage, Resource resource)
		{
			resourcesStored.Remove(resource);
			storage.Add(resource);
		}
	}
}
