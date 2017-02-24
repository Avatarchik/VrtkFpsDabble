using UnityEngine;

public class EnemyPool : GameObjectPool<Enemy>
{
	public float SpawnTime = 1f;
	public float SpawnRadius = 10f;
	public float SpawnPosY = 1f;

	float _timer;

	protected virtual void Awake()
	{
		_timer = SpawnTime;
	}

	protected virtual void Update()
	{
		_timer -= Time.deltaTime;
		if (_timer <= 0f)
		{
			_timer = SpawnTime;

			var enemy = Spawn();
			if (enemy)
			{
				var r = Random.Range(0f, Mathf.PI * 2f);
				var pos = new Vector3(Mathf.Sin(r), 0f, Mathf.Cos(r)) * SpawnRadius;
				pos.y = SpawnPosY;
				enemy.transform.position = pos;
			}

		}
	}
}
