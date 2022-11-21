using UnityEngine;

namespace GamePlay
{
    public class TestSoundMaker : MonoBehaviour
    {
        /*
            create SerailizeField for dragging in unity
        */
        [SerializeField] private AudioSource source = null;

        [SerializeField] private float soundRange = 25f;
        
        [SerializeField] private Sound.SoundType soundType = Sound.SoundType.Interesting;

        private void Start()
        {
            if (source.isPlaying) //If already playing a sound, don't allow overlapping sounds 
                return;

            source.Play();//Play Sound
            
            var sound = new Sound(transform.position, soundRange, soundType);//create self define Sound variable
           
            Sounds.MakeSound(sound);//create sender
            
        }
    }
}
