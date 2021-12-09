using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_camera : MonoBehaviour
{
	public GameObject mainCamera;
	public GameObject screen_camera;
    
	// Start is called before the first frame update
	void Start()
	{
		mainCamera.SetActive(true);
		screen_camera.SetActive(false);
        
	}

	public void open_screen_camera()
	{
		mainCamera.SetActive(true);
		screen_camera.SetActive(true);
	}

	public void close_screen_camera()
	{
		mainCamera.SetActive(true);
		screen_camera.SetActive(false);
	}
	

}
