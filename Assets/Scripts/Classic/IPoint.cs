namespace QuadTreeSolution.Classic {
    public interface IPoint<T> where T : IUserObject {
        T GetUserObject ();
    }
}