using GameLogic;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class ScoreView : MonoBehaviour
    {
        private TMP_Text _score;

        private void Awake()
        {
            _score = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _score.text = GameProgressSaver.GetTime() + "seconds";
        }
    }
}