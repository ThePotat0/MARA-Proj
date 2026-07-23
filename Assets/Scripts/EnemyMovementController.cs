using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float _movementSpeed = 0;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        if (_agent.isOnNavMesh)
        {
            _agent.SetDestination(FindAnyObjectByType<PickUpController>().transform.position);
            _agent.isStopped = false;
        }
    }

    private void FixedUpdate()
    {
        _agent.SetDestination(FindAnyObjectByType<PickUpController>().transform.position);
        _agent.speed = _movementSpeed;
    }
}
