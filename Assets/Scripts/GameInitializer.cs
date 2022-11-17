using ControlPlayerScripts;
using StorageScripts;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
	public PlayerController player;
	public PlayerStock playerStock;
	public Camera mainCamera;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		GameManager.player = player;
		GameManager.playerStock = playerStock;
		GameManager.mainCamera = mainCamera;
	}
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		Destroy(gameObject);
	}
}
