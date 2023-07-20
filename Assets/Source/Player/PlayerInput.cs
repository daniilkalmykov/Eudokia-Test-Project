using GameLogic;
using Interfaces;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Player
{
    [RequireComponent(typeof(PlayerInitializer))]
    public sealed class PlayerInput : MonoBehaviour
    {
        [SerializeField] private CannonShooter _cannonShooter;

        private PlayerInitializer _playerInitializer;
        private IShooter _shooter;

        private void Awake()
        {
            _playerInitializer = GetComponent<PlayerInitializer>();

            _shooter = _cannonShooter;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) == false)
                return;

            var position =
                _playerInitializer.RaycastCreator.GetDirection(Input.mousePosition, _shooter.ShootingDistance);

            _shooter.Shoot(new Vector3(position.x, position.y, position.z));
        }
    }
}