using System.Collections;
using UnityEngine;

namespace StorageScripts
{
	public class StoragePlace : MonoBehaviour
	{
		private Resource _storedResource;
	
		public void Add(Resource resource)
		{
			_storedResource = resource;
			resource.MoveTo(transform);
		}
	
		public void Remove(Transform position)
		{
			_storedResource.MoveTo(position);
			StartCoroutine(DestroyResource(_storedResource));
			Clear();
		}
	
		public void Clear()
		{
			_storedResource = null;
		}
	
		public bool IsEmpty()
		{
			if(_storedResource == null) return true;
			return false;
		}
	
		public bool Contains(Resource resource)
		{
			if(_storedResource != null)
				if(_storedResource == resource) return true;
			return false;
		}
	
		IEnumerator DestroyResource(Resource resourse)
		{
			yield return new WaitUntil(() => !resourse.moving);
			Destroy(resourse.gameObject);
		}
	}
}
