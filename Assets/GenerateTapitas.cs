using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTapitas : MonoBehaviour {

    public GameObject[] tapitas;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;

    int tapita;

    // Use this for initialization
    void Start () {
        GameObject prefap = Resources.Load("tapitaAzul") as GameObject;
        GameObject prefap2 = Resources.Load("tapitaGreen") as GameObject;
        GameObject prefap3 = Resources.Load("tapitaRed") as GameObject;
        StartCoroutine(waitSpawner());
        for (int i = 0; i < 20; i++){
            GameObject go = Instantiate(prefap) as GameObject;
            go.transform.position = new Vector3(Random.Range(0, spawnValues.x), 1, Random.Range(0, spawnValues.z));
        }
        for (int i = 0; i < 50; i++)
        {
            GameObject go = Instantiate(prefap2) as GameObject;
            go.transform.position = new Vector3(Random.Range(0, spawnValues.x), 1, Random.Range(0, spawnValues.z));
        }
        for (int i = 0; i < 200; i++)
        {
            GameObject go = Instantiate(prefap3) as GameObject;
            go.transform.position = new Vector3(Random.Range(0, spawnValues.x), 1, Random.Range(0, spawnValues.z));
        }
    }
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        Debug.Log("Spawn wait: "+spawnWait);
	}

    IEnumerator waitSpawner(){
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < 100; i++)
        {
            tapita = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(Random.Range(0, spawnValues.x), 1, Random.Range(0, spawnValues.z));
            Instantiate(tapitas[tapita], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
            yield return new WaitForSeconds(startWait);
            tapita++;
        }
    }
}
