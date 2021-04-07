using UnityEngine;

namespace QuadTreeSolution.Classic {
    public class DebugRenderingQuadTreeVisitor : IQuadTreeVisitor {
        public void Visit (IQuadTree aQuadTree) {
            DrawBoundary (aQuadTree.GetBoundary ());
        }

        private void DrawBoundary (IRectangle aBoundary) {
            UnityEditor.Handles.color = Color.green;
            DrawRectangle (aBoundary);
        }

        private void DrawRectangle (IRectangle aRectangle) {
            UnityEditor.Handles.DrawPolyLine (new Vector3 (aRectangle.GetX (), aRectangle.GetY ()),
                new Vector3 (aRectangle.GetX (), aRectangle.GetY () + aRectangle.GetHeight ()),
                new Vector3 (aRectangle.GetX () + aRectangle.GetWidth (), aRectangle.GetY () + aRectangle.GetHeight ()),
                new Vector3 (aRectangle.GetX () + aRectangle.GetWidth (), aRectangle.GetY ()), new Vector3 (aRectangle.GetX (), aRectangle.GetY ()));
        }
    }
}