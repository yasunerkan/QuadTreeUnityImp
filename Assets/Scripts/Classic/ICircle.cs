namespace QuadTreeSolution.Classic {
    public interface ICircle : IShape {
        void SetCenterX (float aCenterX);

        void SetCenterY (float aCenterY);

        float GetRadius ();

        void SetRadius (float aRadius);
    }
}