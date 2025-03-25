using UnityEngine;
using TMPro;

public class Jeu : MonoBehaviour
{
    public Roche[] roches;
    public float delaiDebut = 10f;
    public float dureeJeu = 30f;
    private float timer = 0f;
    private float prochainSpawn = 0f;
    private bool jeuCommence = false;

    void Start()
    {
        timer = dureeJeu;
        Invoke(nameof(DemarrerJeu), delaiDebut);
    }

    void DemarrerJeu()
    {
        jeuCommence = true;
    }

    void Update()
    {
        if (!jeuCommence)
            return;

        timer -= Time.deltaTime;

        if (timer > 0)
        {
            prochainSpawn -= Time.deltaTime;

            if (prochainSpawn <= 0)
            {
                LancerRoche();
                prochainSpawn = 3f;
            }
        }
        else
        {
            foreach (var roche in roches)
                roche.Redescendre();
        }
    }

    void LancerRoche()
    {
        int index = Random.Range(0, roches.Length);
        roches[index].Monter();
    }
}
