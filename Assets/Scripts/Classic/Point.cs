namespace QuadTreeSolution.Classic {
    public class Point<T> : IPoint<T> where T : IUserObject {

        private float x;
        private float y;
        private T userObject;

        public Point (float aX, float aY, T aUserObject) {
            this.x = aX;
            this.y = aY;
            this.userObject = aUserObject;
        }

        public float GetX () {
            return this.x;
        }

        public float GetY () {
            return this.y;
        }

        public T GetUserObject () {
            return this.userObject;
        }
    }
}