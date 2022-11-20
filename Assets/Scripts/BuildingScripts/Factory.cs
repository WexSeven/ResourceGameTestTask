using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
    [Tooltip("The storage from which resources are supplied to the building")] [SerializeField]
    private EntryStorage _entryStorage;

    [Header("UI Elements")]
    [Tooltip("A panel that displays that there is no space in the exit storage")]
    [SerializeField]
    private OnBuildingUIElement _noSpaceUI;

    [Tooltip("A panel that displays that there are no resources in the entry storage")] [SerializeField]
    private OnBuildingUIElement _noResourcesUI;

    [Tooltip(
        "What resources the building uses for production (only these resources can be loaded into the entry storage)")]
    [SerializeField]
    private List<Resource> _allowedResources;

    public EntryStorage EntryStorage => _entryStorage;

    protected void Awake()
    {
        EntryStorage.SetAllowedResources(_allowedResources);
    }

    protected void FixedUpdate()
    {
        if (!Working && !ExitStorage.IsFull() && !EntryStorage.IsEmpty())
        {
            if (UseResource())
            {
                Working = true;
                StartCoroutine(ProduceResource());
            }
        }

        _noSpaceUI.SetActive(ExitStorage.IsFull());
        _noResourcesUI.SetActive(EntryStorage.IsEmpty() && !Working);
    }

    private bool UseResource()
    {
        List<Resource> usableResources = new List<Resource>();
        foreach (Resource allowedResource in _allowedResources)
        {
            Resource resource = EntryStorage.GetLastResource(allowedResource);
            if (resource != null)
            {
                usableResources.Add(resource);
            }
        }

        if (usableResources.Count == _allowedResources.Count)
        {
            foreach (Resource resource in usableResources)
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