using UnityEngine;

namespace QuadTreeSolution.Classic {
    public interface IUserObject : IDamageable {
        GameObject GetGameObject ();
        IShape GetShape ();
    }
}