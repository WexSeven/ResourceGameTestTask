using UnityEngine;

public class Mine : Building
{
    [Header("UI Elements")]
    [Tooltip("A panel that displays that there is no space in the exit storage")]
    [SerializeField]
    private OnBuildingUIElement _noSpaceUI;

    protected void FixedUpdate()
    {
        if (!Working && !ExitStorage.IsFull())
        {
            Working = true;
            StartCoroutine(ProduceResource());
            return;
        }

        _noSpaceUI.SetActive(ExitStorage.IsFull());
    }
}