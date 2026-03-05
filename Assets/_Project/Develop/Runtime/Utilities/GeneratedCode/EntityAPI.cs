namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransfromComponent TransfromC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransfromComponent>();

		public UnityEngine.Transform Transfrom => TransfromC.Value;

		public bool TryGetTransfrom(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransfromComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransfrom(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransfromComponent() {Value = value}); 
		}

	}
}
