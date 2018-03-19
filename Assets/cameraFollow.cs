using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target;
    private Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        cameraOffset = transform.position - target.transform.position;
//        Debug.Log(target.transform.position.ToString());
//        Debug.Log(transform.position.ToString());
	}

	void FixedUpdate () {
        transform.SetPositionAndRotation( (target.transform.position + cameraOffset), transform.rotation);
	}
}
