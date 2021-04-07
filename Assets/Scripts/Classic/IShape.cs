namespace QuadTreeSolution.Classic {
    public interface IShape {
        float GetCenterX ();

        float GetCenterY ();

        bool IntersectsWithRectangle (IRectangle aRectangle);

        bool IntersectsWithCircle (ICircle aCircle);
    }
}