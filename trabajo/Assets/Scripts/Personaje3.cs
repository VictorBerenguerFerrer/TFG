using System;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public GameObject arrow; 
    public float maxArrowDistance = 2f; 
    public float launchForceScale = 10f; 
    public float friction = 0.95f; 

private float idleVelocityThreshold = 0.05f;
    public bool isDragging = false;
    public bool hasBeenDragged = false;
    private Vector3 dragStartPosition;
    private Rigidbody2D rb;
    private GameObject draggedObject; 
        
 public bool IsMoving = false;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && (hit.collider.CompareTag("jugador4")))
            {
                isDragging = true;
                dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                draggedObject = hit.collider.gameObject; 
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                isDragging = false;
                Vector3 dragEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 launchDirection = (dragEndPosition - dragStartPosition).normalized; 
                float dragDistance = Vector3.Distance(dragStartPosition, dragEndPosition);

                if (dragDistance > maxArrowDistance)
                {
                    dragDistance = maxArrowDistance;
                }

                

                arrow.SetActive(false);
                hasBeenDragged = true;
            }
        }

        if (isDragging)
        {
            arrow.SetActive(true);

            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dragDirection = (currentMousePosition - dragStartPosition).normalized;
            float dragDistance = Vector3.Distance(dragStartPosition, currentMousePosition);

            if (dragDistance > maxArrowDistance)
            {
                dragDistance = maxArrowDistance;
            }

            Vector3 arrowPosition = draggedObject.transform.position - dragDirection * dragDistance;
            arrow.transform.position = arrowPosition;

            float angle = Mathf.Atan2(dragDirection.y, dragDirection.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if(rb.velocity.magnitude > idleVelocityThreshold){
                     IsMoving = true;
            }else{
                IsMoving =false;
            }
    }

  public void LaunchObject()
{
    if (arrow != null)
    {
        Vector3 dragDirection = (transform.position - arrow.transform.position).normalized;
        float dragDistance = Vector3.Distance(arrow.transform.position, transform.position);

        if (dragDistance > maxArrowDistance)
        {
            dragDistance = maxArrowDistance;
        }
       
            rb.velocity = -dragDirection * dragDistance * launchForceScale;
            hasBeenDragged = false;
    }
}
    private void FixedUpdate()
    {
        if (!isDragging && rb != null)
        {
            rb.velocity *= friction;
        }
    }

    

    
   
}
