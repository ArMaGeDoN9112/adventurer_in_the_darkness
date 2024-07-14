using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool OnGround { get; private set; }
    public float Friction { get; private set; }

    private Vector2 _normal;
    private PhysicsMaterial2D _material;


    private void OnCollisionExit2D(Collision2D collision) // 2+ коллайдера перестают взаидойствовать
    {
        OnGround = false;
        Friction = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) // столкновение 2+ коллайдеров
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision) // взаимодействие 2+ объектов более 1 кадра
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void EvaluateCollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            _normal = collision.GetContact(i).normal;
            OnGround |= _normal.y >= 0.6f;
        }
    }

    private void RetrieveFriction(Collision2D collision)
    {
        _material = collision.rigidbody.sharedMaterial;
        // Debug.Log(_material.name);

        Friction = 0;

        if (_material != null)
        {
            Friction = _material.friction;
        }
    }
}