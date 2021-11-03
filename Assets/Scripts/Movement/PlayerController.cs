 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _anim;
    private static readonly int ForwardSpeed = Animator.StringToHash("forwardSpeed");

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();  
        }

        UpdateAnimator();

 

        //Debug.DrawRay(_lastRay.origin, _lastRay.direction * 100, Color.blue);
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if(hasHit)
        {
            _navMeshAgent.destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = _navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        _anim.SetFloat(ForwardSpeed, speed);
    }
}
