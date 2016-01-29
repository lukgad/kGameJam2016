using UnityEngine;
using System.Collections;

public class CameraTools {

	public static Vector3 GetPositionRestrictedToCamera(Vector3 position, Camera camera) {
		// 6 - Make sure we are not outside the camera bounds
		var dist = (position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, dist)
		).x;

		var rightBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (1, 0, dist)
		).x;

		var topBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, dist)
		).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 1, dist)
		).y;

		return new Vector3 (
			Mathf.Clamp (position.x, leftBorder, rightBorder),
			Mathf.Clamp (position.y, topBorder, bottomBorder),
			position.z
		);
	}	

}
