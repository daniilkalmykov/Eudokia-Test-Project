using BehaviorDesigner.Runtime;
using Blinders;

namespace BehaviorDesigner.Enemy.SharedVariables
{
    public sealed class SharedEnemyMovement : SharedVariable<EnemyMovementBlinder>
    {
        public static implicit operator SharedEnemyMovement(EnemyMovementBlinder enemyMovementBlinder) =>
            new SharedEnemyMovement { Value = enemyMovementBlinder };
    }
}