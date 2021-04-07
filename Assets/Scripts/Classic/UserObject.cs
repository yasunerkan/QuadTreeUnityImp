using UnityEngine;
namespace QuadTreeSolution.Classic {
    public class UserObject : IUserObject {

        private int initialHealth;
        private int health;
        private IShape shape;

        private GameObject gameObject;

        public UserObject (int aHealth, IShape aShape, GameObject aGameObject) {
            this.initialHealth = aHealth;
            this.health = aHealth;
            this.shape = aShape;
            this.gameObject = aGameObject;
        }

        public void AddHealth (int aHealth) {
            this.health += aHealth;
        }

        public int GetInitialHealth () {
            return this.initialHealth;
        }

        public int GetHealth () {
            return this.health;
        }

        public void TakeDamage (int aDamage) {
            this.health -= aDamage;
        }

        public IShape GetShape () {
            return this.shape;
        }

        public GameObject GetGameObject () {
            return this.gameObject;
        }
    }
}