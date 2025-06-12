using N19;
using System.Collections;

namespace Project
{
    public interface IExplosion
    {
        IEnumerator Explosion(GameObjectPool objectPool, float delay);
    }
}