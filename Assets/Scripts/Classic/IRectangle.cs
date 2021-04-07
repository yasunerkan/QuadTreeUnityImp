namespace QuadTreeSolution.Classic {
    public interface IRectangle : IShape {
        float GetX ();

        float GetY ();

        float GetWidth ();

        float GetHeight ();

        void SetX (float aX);

        void SetY (float aY);

        void SetWidth (float aWidth);

        void SetHeight (float aHeight);
    }
}