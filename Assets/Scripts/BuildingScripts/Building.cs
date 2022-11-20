using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
	[SerializeField]private int _workTimeInSeconds;
	[SerializeField]private Resource _typeOfResource;
	[SerializeField]private ExitStorage _exitStorage;
	
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
