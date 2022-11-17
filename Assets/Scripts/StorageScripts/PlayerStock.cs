using System.Collections.Generic;
using System.Linq;

namespace StorageScripts
{
	public class PlayerStock : Storage
	{
	
		public override void Add(Resource resource)
		{
			var target = resourcesStored.Count == 0 ? this.transform : resourcesStored[resourcesStored.Count-1].transform;
			base.Add(resource);
			resource.MoveTo(target);
		}
	
		public Resource GetLastResourseFromAllowed(List<Resource> allowedResources)
		{
			if(resourcesStored.Count > 0)
			{
				for(int i = resourcesStored.Count-1; i >= 0; i--)
				{
					if (allowedResources.Any(t => resourcesStored[i].title.Equals(t.title)))
					{
						return resourcesStored[i];
					}
				}
				return null;
			}
			return null;
		}

		private void UpdateStock()
		{
			for(int i = 0; i < resourcesStored.Count; i++)
			{
				if(i == 0)
				{
					resourcesStored[i].MoveTo(this.transform);
					resourcesStored[i].transform.SetParent(this.transform);
					continue;
				}
				resourcesStored[i].MoveTo(resourcesStored[i-1].transform);
				resourcesStored[i].transform.SetParent(resourcesStored[i-1].transform);
			}
		}
	
		public override void TransferResource(Storage storage, Resource resource)
		{
			base.TransferResource(storage, resource);
			UpdateStock();
		}
	}
}
