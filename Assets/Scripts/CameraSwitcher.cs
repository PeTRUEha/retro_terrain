using UnityEngine;

public class CameraSwitcher: MonoBehaviour
{
    public Camera mainCamera;
    public Camera additionalCamera;
    public Camera rabbitCamera;
    
    public void SelectMainCamera() {
        mainCamera.enabled = true;
        additionalCamera.enabled = false;
        rabbitCamera.enabled = false;
    }
    
    public void SelectAdditionalCamera() {
        mainCamera.enabled = false;
        additionalCamera.enabled = true;
        rabbitCamera.enabled = false;
    }
    
    public void SelectRabbitCamera() {
        mainCamera.enabled = false;
        additionalCamera.enabled = false;
        rabbitCamera.enabled = true;
    }

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        additionalCamera = GameObject.Find("Additional Camera").GetComponent<Camera>();
        rabbitCamera = GameObject.Find("Creatures/Rabbit in hat 1(Clone)/Centre/Model/Camera").GetComponent<Camera>();
        SelectMainCamera();
    }
    
    void Update(){
        if(Input.GetKeyDown("1"))
        {
            SelectMainCamera();
        }
        else if(Input.GetKeyDown("2"))
        {
            SelectAdditionalCamera();
        }
        else if (Input.GetKeyDown("3"))
        {
            SelectRabbitCamera();
        }
    }
}