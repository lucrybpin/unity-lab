using System.Collections.Generic;
using UnityEngine;

public class StrategyPatternUseCaseAttackType : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] List<AttackType> attackTypes;

    void Start()
    {
        AttackType currentAttackType;

        currentAttackType = attackTypes[0];
        currentAttackType.ExecuteAttack(_target);

        currentAttackType = attackTypes[1];
        currentAttackType.ExecuteAttack(_target);
    }
}
