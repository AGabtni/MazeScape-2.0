﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]

    public Transform lookFrom;
    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();
    Animator anim;
    NavMeshAgent _navMeshagent;
    Rigidbody rigidbody;
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;


    public void Start()
    {
        _navMeshagent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine("FindTargetsWithDelay", 0.2f);

       
    }

    private void Update()
    {
     

            anim.SetFloat("Speed", _navMeshagent.velocity.magnitude);
        
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
               
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {

                    //transform.position = Vector3.Slerp(transform.position, target.position, Time.time);
                    
                    visibleTargets.Add(target);

                }
            }
        }
    }

    public void SetDestination(Vector3 targetPosition) {

          _navMeshagent.ResetPath();
          _navMeshagent.SetDestination(targetPosition);
        

    }

    public void ResetDestination()
    {
        _navMeshagent.ResetPath();


    }
}
