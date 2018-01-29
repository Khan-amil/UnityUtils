using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	[System.Serializable]
	public class DropDownList<T>
	{

		[SerializeField]
		protected List<T> _list;
		[SerializeField]
		protected int _value;
		public virtual T Value
		{
			get
			{
				if (_list == null || _value < 0 || _value >= _list.Count)
				{
					return Default();
				}
				return _list[_value];
			}
		}
		public DropDownList ()
		{
			_list = new List<T>();
		}
		public DropDownList(IEnumerable<T> list)
		{
			_list = new List<T>(list);
		} 

		public virtual T Default()
		{
			return default(T);
		}
	}

	[System.Serializable]
	public class DropDownListGo : DropDownList<GameObject>
	{
		public DropDownListGo (IEnumerable<GameObject> list) : base(list)
		{
		} 

		public override GameObject Default ()
		{
			if (Application.isPlaying)
			{
				Debug.LogError("No gameobject set, sending null!");
			}
			return null;
		}

		public void ToggleActiveOnly ()
		{
			for (int i = 0; i < _list.Count; i++)
			{
				if(_list[i]!=null)
					_list[i].SetActive(i == _value);
			}
		}

		public void ToggleAll (bool state = false)
		{
			for (int i = 0; i < _list.Count; i++)
			{
				if (_list[i] != null)
					_list[i].SetActive(state);
			}
		}

		public void SelectRandom ()
		{
			_value = Random.Range(0, _list.Count);
		}
	}

	[System.Serializable]
	public class DropDownListMat: DropDownList<Material>
	{
		public override Material Default()
		{
			if (Application.isPlaying)
			{
				Debug.LogError("No material set, reverting to default!");
			}
			return new Material(Shader.Find("Standard"));
		}
	}

	[System.Serializable]
	public class DropDownListMesh : DropDownList<Mesh>
	{
		public override Mesh Default()
		{
			if (Application.isPlaying)
			{
				Debug.LogError("No mesh set, null passed!");
			}
			return null;
		}
	}
}