using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour {

	[SerializeField]
	Transform rotationCenter;
	public float angle;

	[SerializeField]
	float rotationRadius = 7f, angularSpeed = 1f;

	float posX = 0f;
	float posY = 0f;

	// Update is called once per frame
	private void FixedUpdate() {
		angularSpeed += 0.07f;
		rotationRadius -= 0.03f;
		posX = rotationCenter.position.x + Mathf.Cos (angle) * rotationRadius;
		posY = rotationCenter.position.y + Mathf.Sin (angle) * rotationRadius;
		transform.position = new Vector2 (posX, posY);
		angle = angle + Time.deltaTime * angularSpeed;

		if (angle >= 360f)
			angle = 0f;

		if (rotationRadius <= 1f)
			rotationRadius = 1f;
	}
}
