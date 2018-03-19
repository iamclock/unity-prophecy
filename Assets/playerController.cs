using UnityEngine;




public class playerController : MonoBehaviour {

	// Use this for initialization

    private AnimationClip moving;
    public AnimationClip run;
    public AnimationClip walk;
    public AnimationClip idle;

	[SerializeField]
	float moveSpeed = 4f;
	Vector3 forward, right;

	
	void Start () {
//        walk = GetComponent<Animation>("");
//        run = ;
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}


	// Update is called once per frame
	void Update () {
		if (Input.anyKey) Move();
        else gameObject.GetComponent<Animation>().Play(idle.name);
    }


	void Move(){
        if( Input.GetButtonDown("SpeedUp") ){
            moveSpeed = 8f;
            moving = run;
            Debug.Log(moveSpeed.ToString());
		}
        else {
			moveSpeed = 4f;
            moving = walk;
		}
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
        gameObject.GetComponent<Animation>().Play(moving.name);


        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
