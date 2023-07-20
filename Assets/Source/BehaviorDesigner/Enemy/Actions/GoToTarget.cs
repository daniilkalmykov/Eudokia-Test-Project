using System;
using System.Linq;
using BehaviorDesigner.Enemy.SharedVariables;
using BehaviorDesigner.Runtime.Tasks;
using Interfaces;
using UnityEngine;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

namespace BehaviorDesigner.Enemy.Actions
{
    public sealed class GoToTarget : Action
    {
        public SharedEnemyMovement SharedEnemyMovement;
        public SharedEnemyTargetsHolder SharedEnemyTargetsHolder;

        private Vector3 _targetPosition;
        private IMovable _movable;
        
        public override void OnStart()
        {
            var target = SharedEnemyTargetsHolder.Value.GetTargets().FirstOrDefault(blinder =>
                blinder.EnemyTarget == SharedEnemyMovement.Value.EnemyMovement.Target);

            if (target == null)
                throw new ArgumentNullException();

            _targetPosition = target.transform.position;
            _movable = SharedEnemyMovement.Value.EnemyMovement;
        }

        public override TaskStatus OnUpdate()
        {
            var position = transform.position;

            position = Vector3.MoveTowards(position, _targetPosition, _movable.Speed * Time.deltaTime);
            transform.position = position;

            return position == _targetPosition ? TaskStatus.Success : TaskStatus.Running;
        }
    }
}