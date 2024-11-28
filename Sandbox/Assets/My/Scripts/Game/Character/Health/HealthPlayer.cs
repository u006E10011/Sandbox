using UnityEngine;

namespace Project
{
    public class HealthPlayer : Health
    {
        public override void Died()
        {
            Debug.Log("Died Player");
        }
    }
}