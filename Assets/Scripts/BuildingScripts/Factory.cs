using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
	[SerializeField]private GameObject _noSpacePanel;
	[SerializeField]private GameObject _noResourcesPanel;
	[SerializeField]private EntryStorage _entryStorage;
	[SerializeField]private List<Resource> _allowedResources;
	
	public EntryStorage EntryStorage => _entryStorage;
	
	protected void Awake()
	{
		EntryStorage.SetAllowedResources(_allowedResources);
	}

	protected void FixedUpdate()
	{
		if(!Working && !ExitStorage.IsFull() && !EntryStorage.IsEmpty())
		{
			if(UseResource())
			{
				Working = true;
				StartCoroutine(ProduceResource());
			}
		}
		_noSpacePanel.SetActive(ExitStorage.IsFull());
		_noResourcesPanel.SetActive(EntryStorage.IsEmpty() && !Working);
	}

	private bool UseResource()
	{
		List<Resource> usableResources = new List<Resource>();
		foreach (Resource allowedResource in _allowedResources)
		{
			Resource resource = EntryStorage.GetLastResource(allowedResource);
			if(resource != null)
			{
				usableResources.Add(resource);
			}
		}
		if(usableResources.Count == _allowedResources.Count)
		{
			Debug.Log(usableResources.Count);
			foreach(Resource resource in usableResources)
			{
				EntryStorage.Remove(resource);
				EntryStorage.RemoveFromPlacesAndLerp(resource, transform);
			}
			usableResources.Clear();
			return true;
		}
		return false;
	}
}
