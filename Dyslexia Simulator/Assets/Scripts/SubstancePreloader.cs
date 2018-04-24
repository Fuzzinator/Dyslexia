using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubstancePreloader : MonoBehaviour {

    public static bool FinishedLoading { get; private set; }
    public List<ProceduralMaterial> substances = new List<ProceduralMaterial>();
    //public GameObject loadingBarParent;
    //public Text loadingBarLabel;
    //public GameObject loadingBarPrefab;

    public int maxLoadingAtOnce = 2;
    private List<ProceduralMaterial> currentlyLoadingSubstances = new List<ProceduralMaterial>();
    private List<ProceduralMaterial> substancesToBeLoaded = new List<ProceduralMaterial>();
    private List<GameObject> loadingBars = new List<GameObject>();

	// Use this for initialization
	void Start () {
		/*if (loadingBarParent != null && loadingBarPrefab != null)
        {
            for (int i = 0; i < maxLoadingAtOnce; i++)
                loadingBars.Add(Instantiate(loadingBarPrefab, loadingBarParent.transform));
        }*/

        maxLoadingAtOnce = Mathf.Max(1, maxLoadingAtOnce);
        foreach (var s in substances)
        {
            if (!(s.loadingBehavior == ProceduralLoadingBehavior.DoNothing || s.loadingBehavior == ProceduralLoadingBehavior.DoNothingAndCache))
            {
                Debug.Log("[" + s.name + "]'s loading behaviour is not set to \"Do Nothing\" or to \"Do Nothing and Cache\"!! Fix this then restart the game!");
                Application.Quit();
            }

            substancesToBeLoaded.Add(s);
        }
	}
	
	// Update is called once per frame
	void Update () {

        FinishedLoading = (substancesToBeLoaded.Count + currentlyLoadingSubstances.Count) == 0;

        var finishedSubstances = new List<ProceduralMaterial>();
        foreach (var s in currentlyLoadingSubstances)
        {
            if (!s.isProcessing)
            {
                print("Finished loading: [" + s.name + "]!");
                finishedSubstances.Add(s);
            }
        }
        
        foreach (var s in finishedSubstances)
        {
            currentlyLoadingSubstances.Remove(s);
        }

       /* if (loadingBarParent != null)
        {
            if (currentlyLoadingSubstances.Count > 0)
            {
                //loadingBarLabel.text = "Please wait to begin game...\n " + (currentlyLoadingSubstances.Count + substancesToBeLoaded.Count) + " substances left to load";

                for (int i = 0; i < loadingBars.Count; i++)
                {
                    loadingBars[i].SetActive(i < currentlyLoadingSubstances.Count);
                    if (i < currentlyLoadingSubstances.Count)
                        loadingBars[i].GetComponentInChildren<Text>().text = "Loading [" + currentlyLoadingSubstances[i].name + "]";
                }
            }
            else
            {
                //loadingBarLabel.text = "All procedual textures loaded!\n Go ahead and play!";
                loadingBars.ForEach(go => go.SetActive(false));
            }
        }*/

        if (currentlyLoadingSubstances.Count < maxLoadingAtOnce && substancesToBeLoaded.Count > 0)
        {
            var s = substancesToBeLoaded[0];
            substancesToBeLoaded.RemoveAt(0);
            currentlyLoadingSubstances.Add(s);

            s.RebuildTextures();
        }
	}
}
