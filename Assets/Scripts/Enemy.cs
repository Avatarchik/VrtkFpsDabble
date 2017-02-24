using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float MoveSpeed = 1f;

	Transform _player;

	void Start()
	{
		_player = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}

	void Update()
	{
		transform.LookAt(_player, Vector3.up);
		transform.Translate(0f, 0f, MoveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		gameObject.SetActive(false);
	}
}
