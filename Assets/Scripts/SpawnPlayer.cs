using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    string whichDoggo;
    public GameObject corgi;
    public GameObject beagle;
    public GameObject pug;
    public GameObject frenchie;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Transform tform = spawnPoint.transform;
        print("tform = " + tform);
        whichDoggo = changeScene.selectedDog;
        print("whichDoggo = " + whichDoggo);
        if (whichDoggo == "beagleCube")
            Instantiate(beagle, tform);
        else if (whichDoggo == "corgiCube")
            Instantiate(corgi, tform);
        else if (whichDoggo == "pugCube")
            Instantiate(pug, tform);
        else if (whichDoggo == "frenchieCube")
            Instantiate(frenchie, tform);
    }
}
