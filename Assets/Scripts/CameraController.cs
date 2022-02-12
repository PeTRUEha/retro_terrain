using UnityEngine;

public class CameraController : MonoBehaviour {
	public float keabordTranslationSpeed = 20f;
	public float mouseTranslationSpeed = 0.25f;
    public float scrollSpeed = 16;

    public float minCameraSize;
    public float maxCameraSize;

	// Use this for initialization
	void Start () {

	}

    Vector2 GetForwardDirection(){
        Vector3 forwardV3 = this.GetComponent<Transform>().forward;
        Vector2 forward = (new Vector2(forwardV3.x, forwardV3.z)).normalized;
        return forward;
	}

	// Update is called once per frame
	void Update () {
        Camera camera = this.GetComponent<Camera>();

        Vector2 forward = GetForwardDirection();
        Vector2 rightward = - Vector2.Perpendicular(forward);
		Vector2 keyboardTranslation = 
            (Input.GetAxis("Vertical") * forward + 
             Input.GetAxis("Horizontal") * rightward) * keabordTranslationSpeed * Time.deltaTime * camera.orthographicSize;
            

        Vector2 mouseTranslation = Vector2.zero;
		if(Input.GetButton("Fire2") && !Input.GetButtonDown ("Fire2"))
			mouseTranslation =
                (- Input.GetAxis("Mouse X") * rightward + 
                 - Input.GetAxis("Mouse Y") * forward) * mouseTranslationSpeed * camera.orthographicSize;

        Vector2 finalTranslation = keyboardTranslation + mouseTranslation;
		transform.Translate(finalTranslation.x, 0, finalTranslation.y, Space.World);

        float newSize = camera.orthographicSize * (1 - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime);
        camera.orthographicSize = Mathf.Min(Mathf.Max(minCameraSize, newSize), maxCameraSize);
	}
}
