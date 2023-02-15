using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoveScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 raycastDirection = Vector3.down;
    private Vector3 targetPosition;

    public Animator Animations;
    public float speed = 0.15f;
    public float roamRadius = 10f;
    public float changeTargetInterval = 4f;
    private float changeTargetTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position + Random.insideUnitSphere * roamRadius;
    }

    private void Update()
    {
        if (changeTargetTimer <= 0)
        {
            targetPosition = transform.position + Random.insideUnitSphere * roamRadius;
            targetPosition.y = transform.position.y;
            changeTargetTimer = changeTargetInterval;
            transform.LookAt(targetPosition);
        }
        else
        {
            changeTargetTimer -= Time.deltaTime;
        }

        Vector3 movement = targetPosition - transform.position;
        movement.y = 0;
        movement = movement.normalized * speed;

        rb.AddForce(movement, ForceMode.VelocityChange);

        if (Vector3.Distance(transform.position, targetPosition) > 0.5f)
        {
            Animations.SetTrigger("walk");
        }
        else
        {
            Animations.SetTrigger("idle");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            rb.velocity = Vector3.one;
        }
    }
}
