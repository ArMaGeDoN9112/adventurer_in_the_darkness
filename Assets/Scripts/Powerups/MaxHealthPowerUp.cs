using UnityEngine;

public class HealthPowerup : MonoBehaviour, IPowerup
{
    [SerializeField] private int _addToHealthAmount;

    public void Apply(GameObject target)
    {
        target.GetComponent<Health>()?.IncreaseHealth(_addToHealthAmount);
    }
}