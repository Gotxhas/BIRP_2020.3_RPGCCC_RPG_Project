using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent _navMeshAgent;
    private Ray _lastRay;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.destination = target.position;

        if (Input.GetMouseButtonDown(0))
        {
            _lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        Debug.DrawRay(_lastRay.origin, _lastRay.direction * 100, Color.blue);
    }
}
