using UnityEngine;
using VRTK;

[RequireComponent(typeof(Rigidbody))]
public class Shottie : VRTK_InteractableObject
{
	[Header("Shottie Properties", order = 4)]

	public BulletPool BulletPool;
	public Transform BulletSpawnPoint;

	public float BulletSpeed = 1500;

	Rigidbody _rigidbody;

	protected override void Awake()
	{
		base.Awake();

		_rigidbody = GetComponent<Rigidbody>();
	}

	public override void Grabbed(GameObject currentGrabbingObject)
	{
		base.Grabbed(currentGrabbingObject);
	}

	public override void Ungrabbed(GameObject previousGrabbingObject)
	{
		base.Ungrabbed(previousGrabbingObject);

		// drop the gun if the first grabbing controller has ungrabbed
		if (!GetGrabbingObject())
		{
			_rigidbody.isKinematic = false;
		}
	}

	public override void StartUsing(GameObject currentUsingObject)
	{
		// only the first grabbing controller can shoot
		if (currentUsingObject != GetGrabbingObject())
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
