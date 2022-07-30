using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformY : MonoBehaviour
{
	public float speed = 1f;
	public float minY;
	public float maxY;
	public float waitingTime = 2f;

	private GameObject _target;


	void Start()
	{
		UpdateTarget();
		StartCoroutine("PatrolToTarget");
	}

	void Update()
	{

	}


	private void UpdateTarget()
	{
		// If first time, create target in the left
		if (_target == null)
		{
			_target = new GameObject("Target");
			_target.transform.position = new Vector2(transform.position.x, minY);
			transform.localScale = new Vector3(-1, 1, 1);
			return;
		}

		// If we are in the left, change target to the right
		if (_target.transform.position.y == minY)
		{
			_target.transform.position = new Vector2(transform.position.x, maxY);
		}

		// If we are in the right, change target to the left
		else if (_target.transform.position.y == maxY)
		{
			_target.transform.position = new Vector2(transform.position.x, minY);

		}
	}

	private IEnumerator PatrolToTarget()
	{
		// Coroutine to move the enemy
		while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
		{
			// let's move to the target
			Vector2 direction = _target.transform.position - transform.position;
			float yDirection = direction.y;

			transform.Translate(direction.normalized * speed * Time.deltaTime);

			// IMPORTANT
			yield return null;
		}

		// At this point, i've reached the target, let's set our position to the target's one
		transform.position = new Vector2(_target.transform.position.x, transform.position.y);

		// And let's wait for a moment
		yield return new WaitForSeconds(waitingTime); // IMPORTANT

		// once waited, let's restore the patrol behaviour
		UpdateTarget();
		StartCoroutine("PatrolToTarget");
	}
}
