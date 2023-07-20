namespace Models.Enemy
{
    public sealed class EnemyTarget
    {
        public bool IsAvailable { get; private set; } = true;

        public void SetAvailable()
        {
            IsAvailable = true;
        }

        public void SetUnavailable()
        {
            IsAvailable = false;
        }
    }
}