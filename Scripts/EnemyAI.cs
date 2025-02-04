using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private  Transform[] _waipoints;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    private int currentWaypointIndex = 0;

    private void Update()
    {
        Transform targetWaipoint = _waipoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaipoint.position, _speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetWaipoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % _waipoints.Length;
        }
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * _speedRotation);

    }
}