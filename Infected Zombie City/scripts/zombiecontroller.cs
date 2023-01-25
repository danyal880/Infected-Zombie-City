using UnityEngine;
using UnityEngine.AI;


public class zombiecontroller : MonoBehaviour
{
  
    public GameObject ourplayer;
    public float fov = 120f;
    public float viewdistance= 10f;
    private bool isaware=false;
    NavMeshAgent agent;
    public float wanderRadius = 7f;
    Vector3 wanderpoint;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderpoint = makewaderpoints();
    }

    private void Update()
    {
        if (isaware)
        {
            agent.SetDestination(ourplayer.transform.position);
        }
        else
        {
            searchforplayer();
        }
        wander();
    }

   public void searchforplayer ()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(ourplayer.transform.position))< 120/2 )
        {
            if (Vector3.Distance(ourplayer.transform.position, transform.position)<viewdistance)
            {
               yesAware();
                /*RaycastHit hit;
                if (Physics.Linecast(transform.position,ourplayer.transform.position, out hit))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        yesAware();

                    }
                }*/
            }
        }
    }

    public void yesAware()
    {
        isaware = true;
    }
    public void wander()
    {
        if (Vector3.Distance(transform.position,wanderpoint)<2f)
        {
            wanderpoint = makewaderpoints();
        }
        else
        {
            agent.SetDestination(wanderpoint);
        }

    }
    

    // making random points for zombies to move
    public Vector3 makewaderpoints() 
    {
        Vector3 wanderpoint = (Random.insideUnitSphere * wanderRadius)+ transform.position;
        NavMeshHit navhit;
        NavMesh.SamplePosition(wanderpoint, out navhit, wanderRadius, -1);
        return new Vector3(navhit.position.x, transform.position.y, navhit.position.z);
    }


}
