using UnityEngine;

namespace GamePlay
{
    public static class Sounds 
    {
        public static void MakeSound(Sound sound) 
        {
            //Sender, sending soundwave in a certain radius to collide into NPC (simulate hearing)
            Collider[] col = Physics.OverlapSphere(sound.pos, sound.range);


            /*
                To check that if it's in range
            */
            for (int i = 0; i < col.Length; i++)
                if (col[i].TryGetComponent(out IHear hearer))
                    hearer.RespondToSound(sound);//NPC react to sound
            
        }
    }
}
