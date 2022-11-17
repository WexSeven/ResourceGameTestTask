using System.Collections.Generic;
using StorageScripts;
using UnityEngine;

namespace BuildingScripts
{
	public class Factory : Building
	{
		public EnterStorage enterStorage;
		public List<Resource> allowedResources;
	
		public GameObject NoSpacePanel;
		public GameObject NoResourcesPanel;
	
		// Awake is called when the script instance is being loaded.
		protected void Awake()
		{
			enterStorage.SetAllowedResources(allowedResources);
		}

		// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
		protected void FixedUpdate()
		{
			if(!working && !exitStorage.IsFull() && !enterStorage.IsEmpty())
			{
				if(UseResource())
				{
					working = true;
					StartCoroutine(ProduceResource());
				}
			}

			NoSpacePanel.SetActive(exitStorage.IsFull());

			if(enterStorage.IsEmpty() && !working)
			{
				NoResourcesPanel.SetActive(true);
			}
			else
			{
				NoResourcesPanel.SetActive(false);
			}
		}

		private bool UseResource()
		{
			List<Resource> usableResources = new List<Resource>();
			foreach (Resource allowedResource in allowedResources)
			{
				Resource resource = enterStorage.GetLastResourceOfType(allowedResource);
				if(resource != null)
				{
					usableResources.Add(resource);
				}
			}
			if(usableResources.Count == allowedResources.Count)
			{
				foreach(Resource resource in usableResources)
				{
					enterStorage.Remove(resource);
					enterStorage.RemoveFromPlacesAndLerp(resource, transform);
				}
				usableResources.Clear();
				return true;
			}
			return false;
		}
	}
}
