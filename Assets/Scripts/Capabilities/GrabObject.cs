using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float maxDistance = 0f;
    [SerializeField] private Transform holdpoint;
    [SerializeField, Range(0f, 10f)] private float smooth;
    [SerializeField, Range(0f, 10f)] private float horizontalStrength;
    [SerializeField, Range(0f, 10f)] private float verticalStrength;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask grabbableLayer;

    private Rigidbody2D body, bodyGrabbed;
    private GameObject currentlyGrabbedObject;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentlyGrabbedObject == null)
                GetNearestObject();       
            else
            {
                bodyGrabbed.gravityScale = 1;
                bodyGrabbed.velocity = new Vector2(
                    body.velocity.x * horizontalStrength,
                    Mathf.Abs(body.velocity.x) * verticalStrength
                );

                bodyGrabbed.excludeLayers = 0;
                currentlyGrabbedObject = null;
            }
        }

        if (currentlyGrabbedObject != null)
        {
            bodyGrabbed.velocity = new Vector2(0f, 0f);
            bodyGrabbed.excludeLayers = playerLayer;
            bodyGrabbed.gravityScale = 0;

            currentlyGrabbedObject.transform.position = Vector2.Lerp(
                currentlyGrabbedObject.transform.position,
                holdpoint.position,
                smooth * Time.deltaTime
            );
        }
    }

    private void GetNearestObject()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(
            transform.position,
            maxDistance,
            Vector2.zero,
            0,
            grabbableLayer
        );

        float minDistance = maxDistance;
        GameObject closest = null;

        foreach (RaycastHit2D hit in hits)
        {
            float distance = Vector3.Distance(hit.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = hit.transform.gameObject;
            }
        }
        
        currentlyGrabbedObject = closest;
        if (currentlyGrabbedObject != null)
            bodyGrabbed = currentlyGrabbedObject.GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}