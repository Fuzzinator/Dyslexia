using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour {

    public GameObject mainCam;
    public GameObject menuCam;
    public GameObject menu;
    public GameObject cursor;
    private bool _menuOpen = false;

	// Use this for initialization
	public void Start () {
        _menuOpen = false;
        mainCam.SetActive(true);
        menuCam.SetActive(false);
        menu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
		if (Input.GetButtonDown("Cancel"))
        {
            if (_menuOpen == false)
            {
                _menuOpen = true;
                mainCam.SetActive(false);
                menuCam.SetActive(true);
                menu.SetActive(true);
                cursor.SetActive(false);
            }
            else if (_menuOpen == true)
            {
                _menuOpen = false;
                mainCam.SetActive(true);
                menuCam.SetActive(false);
                menu.SetActive(false);
                cursor.SetActive(true);
            }
        }
	}
}
