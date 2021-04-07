using QuadTreeSolution.Classic;
using System;

namespace QuadTreeSolution.Classic
{
    public class Circle : ICircle
    {

        private float centerX;
        private float centerY;
        private float radius;

        public Circle() { }

        public Circle(float aCenterX, float aCenterY, float aRadius)
        {
            centerX = aCenterX;
            centerY = aCenterY;
            radius = aRadius;
        }

        public float GetCenterX()
        {
            return centerX;
        }

        public float GetCenterY()
        {
            return centerY;
        }

        public float GetRadius()
        {
            return radius;
        }

        public void SetCenterX(float aCenterX)
        {
            centerX = aCenterX;
        }

        public void SetCenterY(float aCenterY)
        {
            centerY = aCenterY;
        }

        public void SetRadius(float aRadius)
        {
            radius = aRadius;
        }

        public bool IntersectsWithRectangle(IRectangle aRectangle)
        {
            return aRectangle.IntersectsWithCircle(this);
        }

        public bool IntersectsWithCircle(ICircle aCircle)
        {
            float distanceX = GetCenterX() - aCircle.GetCenterX();
            float distanceY = GetCenterY() - aCircle.GetCenterY();
            double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
            return distance <= GetRadius() + aCircle.GetRadius();
        }

    }
}