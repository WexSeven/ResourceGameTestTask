using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Storage : MonoBehaviour
{
	public int MaximumCapacity;
	public List<Resource> StoredResources;
	
	
	public virtual void Add(Resource resource)
	{
		if(!IsFull())
		{
			StoredResources.Add(resource);
		}
	}
	
	public virtual void Remove(Resource resource)
	{
		resource.transform.SetParent(null);
		StoredResources.Remove(resource);
	}
	
	public bool IsEmpty()
	{
		if(StoredResources.Count == 0) return true;
		return false;
	}
	
	public bool IsFull()
	{
		if(StoredResources.Count == MaximumCapacity) return true;
		return false;
	}
	
	public Resource GetLastResource(Resource resource)
	{
		if(!IsEmpty())
		{
			for(int i = StoredResources.Count-1; i >= 0; i--)
			{
				if(StoredResources[i].IsEqual(resource))
				{
					return StoredResources[i];
				}
			}
			return null;
		}
		return null;
	}
	
	public Resource GetLastResourceFromList(List<Resource> list)
	{
		if(!IsEmpty())
		{
			for(int i = StoredResources.Count-1; i >= 0; i--)
			{
				if (list.Any(resource => StoredResources[i].IsEqual(resource)))
				{
					return StoredResources[i];
				}
			}
			return null;
		}
		return null;
	}
}
