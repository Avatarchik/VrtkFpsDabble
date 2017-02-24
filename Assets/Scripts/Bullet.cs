using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	public float LifeTime = 5f;

	float _timer;

	public Rigidbody Rigidbody { get; private set; }

	void Awake()
	{
		Rigidbody = GetComponent<Rigidbody>();
	}

	void OnEnable()
	{
		_timer = LifeTime;

		Rigidbody.velocity = Vector3.zero;
		Rigidbody.angularVelocity = Vector3.zero;
	}

	void Update()
	{
		_timer -= Time.deltaTime;
		if (_timer <= 0)
			gameObject.SetActive(false);
	}
}
