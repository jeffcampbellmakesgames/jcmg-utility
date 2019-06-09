using UnityEngine;

namespace JCMG.Utility
{
	/// <summary>
	/// A singleton-pattern object that offers static access to an object, but that object must be
	/// present in the current scene.
	/// </summary>
	public class SceneSingleton<T> : MonoBehaviour where T : Component
	{
		private static bool _applicationIsQuitting = false;

		private static T _instance = null;

		/// <summary>
		/// Returns true if this instance exists, otherwise false.
		/// </summary>
		public static bool Exists => _instance != null;

		/// <summary>
		/// The scene instance of <typeparamref name="T"/>
		/// </summary>
		public static T Instance
		{
			get
			{
				if (_instance == null && !_applicationIsQuitting)
				{
					_instance = FindObjectOfType<T>();
				}

				return _instance;
			}
		}

		protected virtual void Awake()
		{
			if (_instance == null)
			{
				_instance = this as T;
			}
			else if (_instance != this)
			{
				Destroy(gameObject);
			}
		}

		protected virtual void OnDestroy()
		{
			_instance = null;
		}

		protected virtual void OnApplicationQuit()
		{
			_instance = null;
			Destroy(gameObject);
			_applicationIsQuitting = true;
		}
	}
}
