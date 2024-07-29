 using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishZone : MonoBehaviour
{
    [SerializeField] private Transform _enemies;
    private Health _health;
    private int _killed;

    private void Awake()
    {
        _killed = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckKilledEnemies();
        if (_killed == _enemies.childCount)
            GameManager.Instance.FinishCurrentLevel();
    }

    private void CheckKilledEnemies()
    {
        for (int i = 0; i < _enemies.childCount; i++)
        {
            _health = _enemies.GetChild(i).GetComponent<Health>();
            if (_health.CurrentHealth == 0)
            {
                _killed++;
            }
        }
    }
}
