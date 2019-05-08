using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] groups;        //Groups gameobject array
    public void spawnNext()
    {   // Random Index
        int i = Random.Range(0, groups.Length);
        Instantiate(groups[i], transform.position, Quaternion.identity);
    }	
	void Start () {
        spawnNext();    //Spawn initial Group
	}	
}