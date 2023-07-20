using Blinders;
using Models;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class WalletView : MonoBehaviour
    {
        [SerializeField] private WalletBlinder _walletBlinder;
        private TMP_Text _money;
        private Wallet _wallet;

        private void Awake()
        {
            _money = GetComponent<TMP_Text>();

            _wallet = _walletBlinder.Wallet;
        }

        private void OnEnable()
        {
            _wallet.MoneyChanged += OnMoneyChanged;
        }

        private void OnDisable()
        {
            _wallet.MoneyChanged -= OnMoneyChanged;
        }

        private void Start()
        {
            SetMoneyText();
        }

        private void OnMoneyChanged()
        {
            SetMoneyText();
        }

        private void SetMoneyText()
        {
            _money.text = _wallet.Money.ToString();
        }
    }
}