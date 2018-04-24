using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{

    public List<GameObject> cubes = new List<GameObject>();
    public List<GameObject> shapes = new List<GameObject>();
    public List<Transform> cubeSpawns = new List<Transform>();
    public List<Transform> shapeSpawns = new List<Transform>();
    public List<int> colorNums = new List<int>();

    // Use this for initialization
    void Start()
    {
        ShuffleCubes();
        ShuffleShapes();
        ShuffleColors();
        ShuffleShapeSpawns();
        SpawnBoxes();
        SpawnShapes();
    }

    void ShuffleCubes()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            GameObject temp = cubes[i];
            int randomIndex = Random.Range(i, cubes.Count);
            cubes[i] = cubes[randomIndex];
            cubes[randomIndex] = temp;
        }
    }

    void ShuffleShapes()
    {
        for (int i = 0; i < shapes.Count; i++)
        {
            GameObject temp = shapes[i];
            int randomIndex = Random.Range(i, shapes.Count);
            shapes[i] = shapes[randomIndex];
            shapes[randomIndex] = temp;
        }
    }

    void ShuffleColors()
    {
        for (int i = 0; i < colorNums.Count; i++)
        {
            int temp = colorNums[i];
            int randomIndex = Random.Range(i, colorNums.Count);
            colorNums[i] = colorNums[randomIndex];
            colorNums[randomIndex] = temp;
        }
    }

    void ShuffleShapeSpawns()
    {
        for (int i = 0; i < shapeSpawns.Count; i++)
        {
            Transform temp = shapeSpawns[i];
            int randomIndex = Random.Range(i, shapeSpawns.Count);
            shapeSpawns[i] = shapeSpawns[randomIndex];
            shapeSpawns[randomIndex] = temp;
        }
    }

    void SpawnBoxes()
    {
        for (int i = 0; i < cubeSpawns.Count; i++)
        {
            GameObject _spawn = Instantiate(cubes[i], cubeSpawns[i]);
            _spawn.transform.localPosition = Vector3.zero;
            _spawn.transform.parent = null;
            AssignColors(_spawn, i);
        }
    }

    void SpawnShapes()
    {
        for (int i = 0; i < shapeSpawns.Count; i++)
        {
            GameObject _spawn = Instantiate(shapes[i], shapeSpawns[i]);
            _spawn.transform.localPosition = Vector3.zero;
            _spawn.transform.parent = null;
            ShuffleColors();
            AssignColors(_spawn, i);
        }
    }

    void AssignColors(GameObject _spawn, int i)
    {
        _spawn.GetComponent<ColorCheck>().SetColor(i);
    }
}