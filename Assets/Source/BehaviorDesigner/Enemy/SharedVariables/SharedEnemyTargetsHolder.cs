using BehaviorDesigner.Runtime;
using Blinders;

namespace BehaviorDesigner.Enemy.SharedVariables
{
    public sealed class SharedEnemyTargetsHolder : SharedVariable<EnemyTargetsHolderBlinder>
    {
        public static implicit operator SharedEnemyTargetsHolder(EnemyTargetsHolderBlinder enemyTargetsHolderBlinder) =>
            new SharedEnemyTargetsHolder { Value = enemyTargetsHolderBlinder };
    }
}