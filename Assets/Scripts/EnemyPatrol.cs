using UnityEngine;


/*Ce script permet à l'ennemi de patrouiller entre plusieurs points de.waypoints*/
public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    private Transform targetWaypoint;
    private int destPoint=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetWaypoint = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = targetWaypoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, targetWaypoint.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            targetWaypoint = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
}
