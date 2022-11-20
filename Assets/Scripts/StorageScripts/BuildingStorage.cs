using UnityEngine;

public class BuildingStorage : Storage
{
    private StoragePlace[] _storagePlaces;

    public override void Add(Resource resource)
    {
        SendToStoragePlace(resource);
        base.Add(resource);
    }

    protected void Awake()
    {
        _storagePlaces = new StoragePlace[MaximumCapacity];
        for (int i = 0; i < _storagePlaces.Length; i++)
        {
            _storagePlaces[i] = transform.GetChild(i).GetComponent<StoragePlace>();
        }
    }

    protected void RemoveFromPlaces(Resource resource)
    {
        for (int i = _storagePlaces.Length - 1; i >= 0; i--)
        {
            if (_storagePlaces[i].Contains(resource))
            {
                _storagePlaces[i].Remove();
                break;
            }
        }
    }

    public void RemoveFromPlacesAndLerp(Resource resource, Transform position)
    {
        for (int i = _storagePlaces.Length - 1; i >= 0; i--)
        {
            if (_storagePlaces[i].Contains(resource))
            {
                Resource removedResource = _storagePlaces[i].StoredResource;
                removedResource.MoveTo(position);
                _storagePlaces[i].Remove();
                break;
            }
        }
    }

    public void SendToStoragePlace(Resource resource)
    {
        if (!IsFull())
        {
            foreach (StoragePlace place in _storagePlaces)
            {
                if (place.IsEmpty())
                {
                    place.Add(resource);
                    break;
                }
            }
        }
    }
}