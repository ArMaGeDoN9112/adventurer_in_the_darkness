using System;
using UnityEngine;


public class PowerupApplier : MonoBehaviour
{
    public static event Action OnPowerupCollected;
    private IPowerup[] _powerups;

    private void Awake()
    {
        _powerups = GetComponents<IPowerup>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ApplyPowerups(collider.gameObject);
        OnPowerupCollected?.Invoke();
        Destroy(gameObject);
    }

    private void ApplyPowerups(GameObject target)
    {
        foreach(IPowerup powerup in _powerups)
            powerup.Apply(target);
    }
}
