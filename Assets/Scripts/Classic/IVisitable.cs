namespace QuadTreeSolution.Classic {
    public interface IVisitable<T> {
        void Accept (T aVisitor);
    }
}