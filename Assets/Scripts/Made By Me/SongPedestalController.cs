using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongPedestalController : MonoBehaviour
{
    // Boolean Variables
    private bool playing;

    //Sprite Variables
    public Sprite play, pause;

    // Image Variables
    public Image button;

    // AudioSource Variables
    public AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        playing = sound.isPlaying;

        // Changes the button's sprite based on whether sound is playing
        if(playing) { button.sprite = pause; }
        else { button.sprite = play; }
    }

    // Plays or Pauses sound
    public void Interact()
    {
        // Pauses
        if(playing) { sound.Pause(); }

        // Plays
        else { sound.Play(); }
    }
}
