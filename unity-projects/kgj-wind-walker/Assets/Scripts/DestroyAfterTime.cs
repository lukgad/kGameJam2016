using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
	public float lifeTime = 1f;

	void Start () {
		Destroy (gameObject, lifeTime);
	}
}
