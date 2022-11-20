using System.Collections;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [Tooltip("How long does it take for a building to create a resource")] [SerializeField]
    private int _workTimeInSeconds;

    [Tooltip("The type of resource to create")] [SerializeField]
    private Resource _typeOfResource;

    [Header("Building storages")] [Tooltip("The storage to which the created resources will be sent")] [SerializeField]
    private ExitStorage _exitStorage;

    public BuildingStorage ExitStorage => _exitStorage;

    protected bool Working;

    protected IEnumerator ProduceResource()
    {
        yield return new WaitForSeconds(_workTimeInSeconds);
        Resource resource = Instantiate(_typeOfResource, transform.position, _typeOfResource.transform.rotation);
        _exitStorage.Add(resource);
        Working = false;
    }
}