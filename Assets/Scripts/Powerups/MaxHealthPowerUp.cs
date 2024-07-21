using UnityEngine;

public class HealthPowerup : MonoBehaviour, IPowerup
{
    [SerializeField] private int _addToHealthAmount;

    public void Apply(GameObject target)
    {
        target.GetComponent<IHealable>()?.IncreaseHealth(_addToHealthAmount);
    }
}