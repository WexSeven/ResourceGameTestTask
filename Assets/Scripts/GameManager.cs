using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Tooltip("Pointer to player controller on scene")] [SerializeField]
    private PlayerController _playerController;

    [Tooltip("Pointer to player inventory on scene")] [SerializeField]
    private PlayerInventory _playerInventory;

    [Tooltip("Pointer to main camera")] [SerializeField]
    private Camera _mainCamera;

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