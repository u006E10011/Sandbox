using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Project
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(NPC))]
    [RequireComponent(typeof(HealthNPC))]
    public class SetDirectionNPC : MonoBehaviour
    {
        [SerializeField] private NPCMovebleAIConfig _config;

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private NPC _npc;
        [SerializeField] private HealthNPC _health;

        private Coroutine _coroutine;

        private void Reset()
        {
            _agent = GetComponent<NavMeshAgent>();
            _npc = GetComponent<NPC>();
            _health = GetComponent<HealthNPC>();
        }

        private void OnEnable()
        {
            _health.OnDied += StopMove;
            _agent.angularSpeed = _config.IdleAndularSpeed;

            _coroutine = StartCoroutine(SetDirection());
        }

        private void OnDisable()
        {
            _health.OnDied -= StopMove;

            StopMove();
        }

        private void Update()
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
                Idle();
        }

        private void StopMove()
        {
            _agent.speed = 0;
            StopCoroutine(_coroutine);
        }

        private IEnumerator SetDirection()
        {
            yield return new WaitForSeconds(RandomDelayToSetDirection());

            if (Random.value < _config.Chance)
            {
                if (NavMesh.SamplePosition(Random.insideUnitCircle * _config.RadiusSpawnPoint, out NavMeshHit hit, _config.RadiusSpawnPoint, -1))
                    Walk(hit);
            }

            _coroutine = StartCoroutine(SetDirection());
        }

        private void Idle()
        {
            _npc.SetIdle();
            _agent.angularSpeed = _config.IdleAndularSpeed;
        }

        private void Walk(NavMeshHit hit)
        {
            _npc.SetWalk();

            _agent.speed = _config.Speed;
            _agent.angularSpeed = _config.WalkAndularSpeed;
            _agent.SetDestination(hit.position);
        }

        private float RandomDelayToSetDirection() => Random.Range(_config.Delay.Min, _config.Delay.Max);
    }
}