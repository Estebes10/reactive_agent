using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour {

    public Transform targetPlayer;

    public float lookRadius = 50f;

    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timeForNewPath;
    public float xPosition;
    public float zPosition;
    bool inCoRoutine;
    Vector3 target;
    bool validPath;

	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
	}
	
    Vector3 getNewRandomPosition(){
        float x = Random.Range(xPosition, xPosition - 50);
        float z = Random.Range(zPosition, zPosition - 50);
        //float x = Random.Range(gameObject.transform.position.x, gameObject.transform.position.x - 100);
        //float z = Random.Range(gameObject.transform.position.z, gameObject.transform.position.z - 100);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator DoSomething(){
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target, path);
        if (!validPath) Debug.Log("Found an invalid path");

        while(!validPath){
            yield return new WaitForSeconds(0.1f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(target, path);
        }

        inCoRoutine = false;
    }

    void GetNewPath(){
        target = getNewRandomPosition();
        navMeshAgent.SetDestination(target);
    }

	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(targetPlayer.position, transform.position);
        if (distance <= lookRadius){
            navMeshAgent.SetDestination(targetPlayer.position);
        }
        if (!inCoRoutine){
            StartCoroutine(DoSomething());
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
