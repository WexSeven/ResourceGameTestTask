using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{
	[SerializeField]private GameObject NoSpacePanel;
	
	protected void FixedUpdate()
	{
		if(!Working && !ExitStorage.IsFull())
		{
			Working = true;
			StartCoroutine(ProduceResource());
			return;
		}
		NoSpacePanel.SetActive(ExitStorage.IsFull());
	}
}
