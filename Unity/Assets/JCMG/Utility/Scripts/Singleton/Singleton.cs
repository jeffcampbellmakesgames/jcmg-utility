using UnityEngine;

namespace JCMG.Utility
{
	/// <summary>
	/// A singleton-pattern object that offers static access to an object.
	/// </summary>
	public abstract class Singleton<T> : MonoBehaviour where T : Component
	{
		#pragma warning disable CS0414
		private static bool _applicationIsQuitting;
		#pragma warning restore CS0414

		private static T _instance = null;

		// Scene Object Paths/Names
		private const string SINGLETON_CONTAINER_NAME = "Singletons";
		private const string SINGLETON_CONTAINER_PATH = "/" + SINGLETON_CONTAINER_NAME;

		// Logs
		private const string INVALID_ACCESS_WARNING =
			"[Singleton] Application is quiting, but something is still calling .instance on a singleton, " +
			"which is going to return null. Use .exists before .instance on cleanup code";

		private const string ALREADY_EXISTS_WARNING_FORMAT =
			"[Singleton] Singleton {0} on object {1} was already found on {2}.";

		// Editor-only block for ensuring that static instance is set as null when leaving play-mode.
		#region Play-Mode Support

		#if UNITY_EDITOR

		static Singleton()
		{
			UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
		}

		private static void OnPlayModeStateChanged(UnityEditor.PlayModeStateChange playModeStateChange)
		{
			// If our new play-mode is anything other than entering edit mode, return.
			if (playModeStateChange != UnityEditor.PlayModeStateChange.EnteredEditMode)
			{
				return;
			}

			_instance = null;
			_applicationIsQuitting = false;
		}

		#endif

		#endregion

		/// <summary>
		/// The global instance of <typeparamref name="T"/>.
		/// </summary>
		public static T Instance
		{
			get
			{
				if (_applicationIsQuitting)
				{
					Debug.LogError(INVALID_ACCESS_WARNING);
				}
				else if (!Exists)
				{
					EnsureExists();
				}

				return _instance;
			}
		}

		/// <summary>
		/// Returns true if this global instance exists, otherwise false.
		/// </summary>
		public static bool Exists => _instance != null;

		/// <summary>
		/// Attempts to ensures that an instance of <typeparamref name="T"/> exists by finding one in the scene if
		/// present, and if not present creating one from scratch.
		/// </summary>
		private static void EnsureExists()
		{
			_instance = FindObjectOfType<T>();

			if (_instance == null)
			{
				_instance = new GameObject(typeof(T).Name).AddComponent<T>();
			}
		}

		protected virtual void Awake()
		{
			if (IsDontDestroyOnLoad())
			{
				DontDestroyOnLoad(gameObject);
			}

			if (IsOrganizedInHierarchy() && IsDontDestroyOnLoad())
			{
				var root = GameObject.Find(SINGLETON_CONTAINER_PATH);
				if (root == null)
				{
					root = new GameObject(SINGLETON_CONTAINER_NAME);
				}

				DontDestroyOnLoad(root);

				transform.SetParent(root.transform);
			}

			if (_instance == null)
			{
				_instance = this as T;
			}
			else
			{
				Debug.LogErrorFormat(this, ALREADY_EXISTS_WARNING_FORMAT, typeof(T), name, _instance.gameObject.name);
			}
		}

		protected virtual void OnApplicationQuit()
		{
			_applicationIsQuitting = true;
		}

		/// <summary>
		/// Returns true if this should be organized under a single "Singletons" root object, otherwise false.
		/// </summary>
		protected virtual bool IsOrganizedInHierarchy()
		{
			return true;
		}

		/// <summary>
		/// Returns true if this should be marked as "DontDestroyOnLoad", otherwise false.
		/// </summary>
		protected virtual bool IsDontDestroyOnLoad()
		{
			return true;
		}
	}
}
