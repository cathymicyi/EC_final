
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	// Use this for initialization
	public float speed = 2.0f;
	public GameObject objectToFollow;
	
	// Update is called once per frame
	void Update () {
		
		float interpolation = speed * Time.deltaTime;
		Vector3 position = this.transform.position;
		position.y = Mathf.Lerp (this.transform.position.y, objectToFollow.transform.position.y, interpolation);
		position.x = Mathf.Lerp (this.transform.position.x, objectToFollow.transform.position.x, interpolation);
		this.transform.position = position;
	}
}
