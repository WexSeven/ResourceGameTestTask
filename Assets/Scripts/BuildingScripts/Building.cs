using System.Collections;
using StorageScripts;
using UnityEngine;

namespace BuildingScripts
{
	public abstract class Building : MonoBehaviour
	{
		public Resource createdResource;
		public float workTime;
		public bool working;
		public Storage exitStorage;

		protected IEnumerator ProduceResource()
		{
			yield return new WaitForSeconds(workTime);
			Resource resource = Instantiate(createdResource, transform.position, createdResource.transform.rotation);
			exitStorage.Add(resource);
			working = false;
		}
	}
}
