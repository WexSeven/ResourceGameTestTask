using UnityEngine;

namespace BuildingScripts
{
	public class Mine : Building
	{
		public GameObject NoSpacePanel;
	
		protected void FixedUpdate()
		{
			if(!working && !exitStorage.IsFull())
			{
				working = true;
				StartCoroutine(ProduceResource());
			}

			NoSpacePanel.SetActive(exitStorage.IsFull());
		}
	}
}
