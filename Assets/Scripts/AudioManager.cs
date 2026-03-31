using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist; // Tableau pour stocker les clips audio
    public AudioSource audioSource; // Composant AudioSource pour jouer les clips
    private int musicIndex = 0; // Index pour suivre la chanson actuelle
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = playlist[0]; // Assigner le premier clip de la playlist à l'AudioSource
        audioSource.Play(); // Jouer le clip
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying) // Vérifier si le clip actuel a fini de jouer
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length; // Calculer l'index du prochain clip (boucle à la fin de la playlist)
        audioSource.clip = playlist[musicIndex]; // Assigner le prochain clip à l'AudioSource
        audioSource.Play(); // Jouer le prochain clip
    }
}
