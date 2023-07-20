using Models;
using UnityEngine;

namespace Blinders
{
    public sealed class WalletBlinder : MonoBehaviour
    {
        public Wallet Wallet { get; private set; } = new Wallet();
    }
}