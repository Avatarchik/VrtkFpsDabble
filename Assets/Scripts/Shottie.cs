using UnityEngine;
using VRTK;

public class Shottie : VRTK_InteractableObject
{
	[Header("Shottie Properties", order = 4)]

	public BulletPool BulletPool;
	public Transform BulletSpawnPoint;

	public float BulletSpeed = 1500;

	GameObject _initialGrabbingObject;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void Grabbed(GameObject currentGrabbingObject)
	{
		base.Grabbed(currentGrabbingObject);

		if (!_initialGrabbingObject)
			_initialGrabbingObject = currentGrabbingObject;
	}

	public override void Ungrabbed(GameObject previousGrabbingObject)
	{
		base.Ungrabbed(previousGrabbingObject);

		if (_initialGrabbingObject == previousGrabbingObject)
			_initialGrabbingObject = null;

		GetComponent<Rigidbody>().isKinematic = false;
	}

	public override void StartUsing(GameObject currentUsingObject)
	{
		if (currentUsingObject != _initialGrabbingObject)
			return;

		base.StartUsing(currentUsingObject);
		var bullet = BulletPool.Spawn();
		if (bullet != null)
		{
			bullet.transform.rotation = BulletSpawnPoint.rotation;
			bullet.transform.position = BulletSpawnPoint.position;
			bullet.Rigidbody.AddForce(BulletSpawnPoint.forward * BulletSpeed);
		}
	}
}
