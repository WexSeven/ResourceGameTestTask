using System.Collections;
using UnityEngine;

public class PlayerInventory : Storage
{
    [Tooltip("Is the process of transferring from / to the player's inventory of the resource now taking place")]
    public bool IsTransferring;

    public void StartTransferring(Resource resource)
    {
        IsTransferring = true;
        StartCoroutine(StopTransferring(resource));
    }

    public IEnumerator StopTransferring(Resource resource)
    {
        yield return new WaitUntil(() => !resource.IsMoving);
        IsTransferring = false;
    }

    public override void Add(Resource resource)
    {
        Transform target = IsEmpty() ? this.transform : StoredResources[StoredResources.Count - 1].transform;
        base.Add(resource);
        resource.MoveTo(target);
    }

    public override void Remove(Resource resource)
    {
        base.Remove(resource);
        UpdateStock();
    }

    public void UpdateStock()
    {
        for (int i = 0; i < StoredResources.Count; i++)
        {
            if (i == 0)
            {
                StoredResources[i].MoveTo(this.transform);
                StoredResources[i].transform.SetParent(this.transform);
                continue;
            }

            StoredResources[i].MoveTo(StoredResources[i - 1].transform);
            StoredResources[i].transform.SetParent(StoredResources[i - 1].transform);
        }
    }
}