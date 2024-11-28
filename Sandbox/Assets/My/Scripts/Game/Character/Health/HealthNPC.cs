using N19;
using Project;
using Unity.VisualScripting;
using UnityEngine;

namespace Project
{
    public class HealthNPC : Health
    {
        [SerializeField] private NPC _npc;

        [ContextMenu(nameof(AddHealthSegment))]
        public void AddHealthSegment()
        {
            GetComponentsInChildren<Collider>(true).ForEach(p =>
            {
                if (p.GetComponent<HealthNPC>() != this)
                {
                    p.TryGetComponent<HealthNPCSegment>(out var health);

                    if (health)
                        DestroyImmediate(health);

                    p.AddComponent<HealthNPCSegment>().Init(this);
                }
            });
        }

        [ContextMenu(nameof(RemoveHealthHegment))]
        public void RemoveHealthHegment()
        {
            GetComponentsInChildren<Collider>(true).ForEach(p =>
            {
                if (p.GetComponent<HealthNPC>() != this)
                {
                    if (p.TryGetComponent<HealthNPCSegment>(out var health))
                        DestroyImmediate(health);
                }
            });
        }
    }
}