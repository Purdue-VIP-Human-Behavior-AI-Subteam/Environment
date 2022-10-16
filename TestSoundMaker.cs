using UnityEngine;

namespace GamePlay
{
    public class TestSoundMaker : MonoBehaviour
    {
        [SerializeField] private AudioSource source = null;

        [SerializeField] private float soundRange = 25f;
        
        [SerializeField] private Sound.SoundType soundType = Sound.SoundType.Interesting;

        private void Start()
        {
            if (source.isPlaying) //If already playing a sound, don't allow overlapping sounds 
                return;

            source.Play();
            
            var sound = new Sound(transform.position, soundRange, soundType);
            //sound.soundType=Sound.SoundType.Interesting;
            Sounds.MakeSound(sound);
            
        }
    }
}
