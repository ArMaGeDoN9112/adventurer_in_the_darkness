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
    private GameObject obj;

    public bool abilityEnabled = false;
    // private bool thrown = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        obj = FindNearestObject();

        if (Input.GetKeyDown(KeyCode.F) && abilityEnabled)
        {
            if (currentlyGrabbedObject == null && obj != null)
            {
                GrabClosestObject(obj);
            }
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
            HintOff(currentlyGrabbedObject);
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

    private GameObject FindNearestObject()
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

        RaycastHit2D[] hitsToOff = Physics2D.CircleCastAll(
            transform.position,
            maxDistance + 1,
            Vector2.zero,
            0,
            grabbableLayer
        );

        foreach (RaycastHit2D hit in hitsToOff)
        {
            HintOff(hit.transform.gameObject);
        }

        if (closest != null && abilityEnabled)
            HintOn(closest);
        return closest;
    }


    private void GrabClosestObject(GameObject target)
    {
        currentlyGrabbedObject = target;
        if (currentlyGrabbedObject != null)
            bodyGrabbed = currentlyGrabbedObject.GetComponent<Rigidbody2D>();
    }

    private bool IsOnDistance(GameObject obj)
    {
        if (Vector2.Distance(transform.position, obj.transform.position) < maxDistance)
        {
            return true;
        }
        return false;
    }

    private void HintOn(GameObject obj)
    {
        GameObject child = obj.transform.GetChild(0).gameObject;
        child.SetActive(true);
        child.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 2, obj.transform.position.z);
        child.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void HintOff(GameObject obj)
    {
        obj.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}