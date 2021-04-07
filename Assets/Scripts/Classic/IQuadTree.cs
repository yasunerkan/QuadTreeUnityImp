using System.Collections.Generic;
namespace QuadTreeSolution.Classic {
    public interface IQuadTree : IVisitable<IQuadTreeVisitor> {
        IRectangle GetBoundary ();

        List<IPoint<IUserObject>> GetRootPoints ();
        bool Insert (IPoint<IUserObject> aPoint, IQuadTreeVisitor aVisitor);

        void RemovePointsFromRoot (List<IPoint<IUserObject>> aPoints);
    }
}