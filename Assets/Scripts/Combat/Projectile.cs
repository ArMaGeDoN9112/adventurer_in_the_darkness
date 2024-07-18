using UnityEngine;

namespace BHSCamp
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _body;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        //STEP 8: Сделайте так, чтобы снаряд уничтожался при столкновении с любым физическим объектом
        // (для уничтожения объекта используйте Destroy(gameObject);)
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }

        // STEP 6: Реализуйте данный метод, чтобы он задавал направление полета снаряду
        public void SetDirection(Vector2 direction)
        {
            _body.velocity = direction * _speed;
        }
    }
}