using System.Linq;
using BehaviorDesigner.Enemy.SharedVariables;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Enemy.Actions
{
    public sealed class SetEnemyTarget : Action
    {
        public SharedEnemyTargetsHolder SharedEnemyTargetsHolder;
        public SharedEnemyMovement SharedEnemyMovement;

        public override TaskStatus OnUpdate()
        {
            var availableTargets = SharedEnemyTargetsHolder.Value.GetTargets().Where(blinder =>
                blinder.EnemyTarget != SharedEnemyTargetsHolder.Value.TargetsHolder.CurrentTarget).ToArray();

            SharedEnemyTargetsHolder.Value.TargetsHolder.SetCurrentTarget(
                availableTargets[Random.Range(0, availableTargets.Length)].EnemyTarget);

            SharedEnemyMovement.Value.EnemyMovement.SetTarget(SharedEnemyTargetsHolder.Value.TargetsHolder.CurrentTarget);
            
            return TaskStatus.Success;
        }
    }
}