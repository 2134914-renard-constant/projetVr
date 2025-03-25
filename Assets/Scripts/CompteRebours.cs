using UnityEngine;
using TMPro;

public class CompteRebours : MonoBehaviour
{
    public float delaiDebut = 10f;
    public TextMeshProUGUI texte;
    private float timer;
    private bool compteActif = true;

    void Start()
    {
        timer = delaiDebut;
    }

    void Update()
    {
        if (!compteActif) return;

        timer -= Time.deltaTime;

        int secondes = Mathf.CeilToInt(timer);
        texte.text = $"Le jeu commence dans {secondes}...";

        if (timer <= 0f)
        {
            texte.text = "GO!";
            compteActif = false;
            Invoke(nameof(CacherTexte), 1f);
        }
    }

    void CacherTexte()
    {
        gameObject.SetActive(false);
    }
}
