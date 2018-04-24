using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorList : MonoBehaviour {

    public List<Material> mats = new List<Material>();
    public static List<Material> staticMats = new List<Material>();

    public List<Material> secretMats = new List<Material>();
    public static List<Material> staticSecretMats = new List<Material>();


    private void Awake()
    {
        foreach(Material mat in mats)
        {
            staticMats.Add(mat);
        }

        foreach (Material mat in secretMats)
        {
            staticSecretMats.Add(mat);
        }
    }

}
