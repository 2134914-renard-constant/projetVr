using UnityEngine;

public class Roche : MonoBehaviour
{

    public Vector3 positionRepos;
    public Vector3 positionMontee;
    public float dureeMontee = 3f;
    public bool estActive = false;
    private float tempsRestant;
    private bool aEteFrappee = false;
    private AudioSource audioSource;
    public AudioClip sonFrappe;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Monter()
    {
        if (estActive) return;

        estActive = true;
        aEteFrappee = false;
        transform.localPosition = positionMontee;
        tempsRestant = dureeMontee;
    }

    void Update()
    {
        if (estActive)
        {
            tempsRestant -= Time.deltaTime;

            if (tempsRestant <= 0f && !aEteFrappee)
            {
                Redescendre();
            }
        }
    }

    public void Redescendre()
    {
        transform.localPosition = positionRepos;
        estActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Massue") && !aEteFrappee)
        {
            aEteFrappee = true;
            audioSource.PlayOneShot(sonFrappe);
            Redescendre();
        }
    }
}
