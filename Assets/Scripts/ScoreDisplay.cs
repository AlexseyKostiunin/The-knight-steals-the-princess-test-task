using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private TMP_Text _score;

    private void OnPrincessesReceived(int numberPrincess)
    {
        _score.text = numberPrincess.ToString();
    }

    private void OnEnable()
    {
        _hero.PrincessesReceived += OnPrincessesReceived;
    }

    private void OnDisable()
    {
        _hero.PrincessesReceived -= OnPrincessesReceived;
    }

}
