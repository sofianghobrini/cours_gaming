using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist; // Tableau pour stocker les clips audio
    public AudioSource audioSource; // Composant AudioSource pour jouer les clips
    public AudioMixerGroup soundEffectsMixer; // Groupe de mixage pour les effets sonores
    private int musicIndex = 0; // Index pour suivre la chanson actuelle
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }
        instance = this;
    } 

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

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio"); // Créer un objet temporaire pour jouer le clip
        tempGO.transform.position = pos; // Positionner l'objet temporaire à la position spécifiée
        AudioSource audioSource = tempGO.AddComponent<AudioSource>(); // Ajouter un composant AudioSource à l'objet temporaire
        audioSource.clip = clip; // Assigner le clip audio à l'AudioSource
        audioSource.outputAudioMixerGroup = soundEffectsMixer;
        audioSource.Play(); // Jouer le clip
        Destroy(tempGO, clip.length); // Détruire l'objet temporaire après la durée du clip
        return audioSource; // Retourner la référence à l'AudioSource pour un contrôle ultérieur si nécessaire
    }
}
