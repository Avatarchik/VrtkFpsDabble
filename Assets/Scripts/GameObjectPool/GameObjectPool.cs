using UnityEngine;

public abstract class GameObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
	public T GameObjectPrefab;

	public int PoolSize = 100;

	T[] _pool;

	protected virtual void Start()
	{
		_pool = new T[PoolSize];

		for (int i = 0; i < PoolSize; i++)
		{
			var go = Instantiate(GameObjectPrefab, transform);
			go.gameObject.SetActive(false);
			_pool[i] = go;
		}
	}

	public virtual T Spawn()
	{
		for (int i = 0; i < PoolSize; i++)
		{
			if (_pool[i].isActiveAndEnabled)
				continue;

			_pool[i].gameObject.SetActive(true);
			return _pool[i];
		}

		Debug.LogWarning("Spawn() called when pool has no available game objects!");
		return null;
	}
}
