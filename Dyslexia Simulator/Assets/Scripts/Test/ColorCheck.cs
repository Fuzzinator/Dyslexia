using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheck : MonoBehaviour {

    public bool secretMat;
    public enum myColor {Red, Pink, Orange, Yellow, Purple, Green, Blue, Brown}
    public myColor color;
    public int colorCount;
	// Use this for initialization
	void Start () {
        //SetColor(colorCount);
	}
	
	public void SetColor(int count)
    {
        switch(count)
        {
            case 0:
                color = myColor.Red;
                
                break;
            case 1:
                color = myColor.Orange;
                //print(count);
                break;
            case 2:
                color = myColor.Yellow;
                //print(count);
                break;
            case 3:
                color = myColor.Purple;
                //print(count);
                break;
            case 4:
                color = myColor.Green;
                //print(count);
                break;
            case 5:
                color = myColor.Blue;
                //print(count);
                break;
            case 6:
                color = myColor.Pink;
                //print(count);
                break;
            case 7:
                color = myColor.Brown;
                //print(count);
                break;

        }
        AssignMat(count);
    }

    void AssignMat(int i)
    {
        if (secretMat)
        {
            GetComponent<Renderer>().material = ColorList.staticSecretMats[i];
        }else
        {
            GetComponent<Renderer>().material = ColorList.staticMats[i];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!secretMat&&other.GetComponent<ColorCheck>().color == color)
        {
            Actions.breakConnection();
            other.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            other.enabled = false;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localEulerAngles = Vector3.zero;
            other.GetComponent<Renderer>().material.SetFloat("_Amount", 0);
        }
    }
}
