using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	
	[SerializeField]private PlayerController _playerController;
	[SerializeField]private PlayerInventory _playerInventory;
	[SerializeField]private Camera _mainCamera;
	
	public PlayerController PlayerController => _playerController;
	public PlayerInventory PlayerInventory => _playerInventory;
	public Camera MainCamera => _mainCamera;
	
	protected void Awake()
	{
		if (Instance != null && Instance != this) 
		{ 
			Destroy(this); 
		} 
		else 
		{ 
			Instance = this; 
		} 
	}
}
