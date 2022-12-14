using System.Collections.Generic;
using UnityEngine;

public class EntryStorage : BuildingStorage
{
    private List<Resource> _allowedResources;

    public void SetAllowedResources(List<Resource> resources)
    {
        _allowedResources = resources;
    }

    protected void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player") && GameManager.Instance.PlayerController.IsStanding())
        {
            if (!IsFull() && !GameManager.Instance.PlayerInventory.IsEmpty() &&
                !GameManager.Instance.PlayerInventory.IsTransferring)
            {
                Resource resource = GameManager.Instance.PlayerInventory.GetLastResourceFromList(_allowedResources);
                if (resource != null)
                {
                    GameManager.Instance.PlayerInventory.Remove(resource);
                    Add(resource);
                    GameManager.Instance.PlayerInventory.StartTransferring(resource);
                }
            }
        }
    }
}