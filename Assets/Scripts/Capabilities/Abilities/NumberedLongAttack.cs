using UnityEngine;



[CreateAssetMenu(fileName = "NumberedLongAttack", menuName = "Abilities/NumberedLongAttack")]
public class NumberedLongAttack : Ability
{
    [SerializeField] private int _numberOfProjectiles;
    private PlayerRangedAttack _rangedAttack;
    public override void Activate(GameObject parent)
    {
        _rangedAttack = parent.GetComponent<PlayerRangedAttack>();
        _rangedAttack.BeginAttackNew(_numberOfProjectiles);
    }

    public override void BeginCooldowm(GameObject parent)
    {
    }
}