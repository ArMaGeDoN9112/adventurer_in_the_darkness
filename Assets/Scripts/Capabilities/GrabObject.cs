using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] public float _maxDistance = 0f;
    public Transform holdpoint;
    private GameObject currentlyGrabbedObject, _root;
    private float _currentDistance, _minDistance;
    [SerializeField, Range(0f, 10f)] private float _smooth;
    [SerializeField, Range(0f, 10f)] private float _horizontalStrength;
    [SerializeField, Range(0f, 10f)] private float _verticalStrength;
    private bool grab = false;
    private Rigidbody2D _body, _bodyGrabbed;
    private Ground _ground;


    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _root = GameObject.Find("Grabbable");
        _minDistance = _maxDistance;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            grab = true;
            GetNearestObject();
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (currentlyGrabbedObject != null)
            {
                _ground = currentlyGrabbedObject.GetComponent<Ground>();

                grab = false;
                _bodyGrabbed.gravityScale = 1;
                _bodyGrabbed.velocity = new Vector2(_body.velocity.x * _horizontalStrength, Mathf.Abs(_body.velocity.x) * _verticalStrength);
                _minDistance = _maxDistance;

                // if (_ground.OnGround)
                //     Physics2D.IgnoreCollision(GetComponent<Collider2D>(), currentlyGrabbedObject.GetComponent<Collider2D>(), false);
                currentlyGrabbedObject = null;
            }
        }

        if (grab && currentlyGrabbedObject != null)
        {

            _bodyGrabbed = currentlyGrabbedObject.GetComponent<Rigidbody2D>();
            _bodyGrabbed.velocity = new Vector2(0f, 0f);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), currentlyGrabbedObject.GetComponent<Collider2D>());
            _bodyGrabbed.gravityScale = 0;
            // currentlyGrabbedObject.transform.position = transform.position;
            currentlyGrabbedObject.transform.position = Vector2.Lerp(currentlyGrabbedObject.transform.position, transform.position, _smooth * Time.deltaTime);

        }
    }

    private void GetNearestObject()
    {
        for (int i = 0; i < _root.transform.childCount; i++)
        {
            GameObject child = _root.transform.GetChild(i).gameObject;

            _currentDistance = Vector2.Distance(transform.position, child.transform.position);

            if (_currentDistance < _maxDistance)
            {
                if (_minDistance == _maxDistance)
                {
                    Debug.Log("Grabbed");
                    _minDistance = _currentDistance;
                    currentlyGrabbedObject = child;
                }
                else if (_currentDistance < _minDistance)
                {
                    _minDistance = _currentDistance;
                    currentlyGrabbedObject = child;
                }
            }
        }
    }
}