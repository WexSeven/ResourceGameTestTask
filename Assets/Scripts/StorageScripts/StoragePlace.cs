using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoragePlace : MonoBehaviour
{
	private Resource _storedResource;
	
	public Resource StoredResource => _storedResource;
	
	public void Add(Resource resource)
	{
		_storedResource = resource;
		resource.MoveTo(transform);
	}
	
	public void Remove()
	{
		_storedResource = null;
	}
	
	public bool IsEmpty()
	{
		if(StoredResource == null) return true;
		return false;
	}
	
	public bool Contains(Resource resource)
	{
		if(!IsEmpty())
		{
			if(StoredResource.IsEqual(resource)) return true;
			return false;
		}
		return false;
	}
}
