using System.Collections.Generic;
using UnityEngine;

namespace QuadTreeSolution.Classic {
    public class InsertQuadTreeVisitor : IQuadTreeVisitor {

        private IPoint<IUserObject> insertedPoint;
        private int damagePoint;
        private IUserObjectSpawner userObjectSpawner;

        public InsertQuadTreeVisitor (int aDamagePoint, IUserObjectSpawner aUserObjectSpawner) {
            this.damagePoint = aDamagePoint;
            this.userObjectSpawner = aUserObjectSpawner;
        }

        public void SetInsertedPoint (IPoint<IUserObject> aInsertedPoint) {
            this.insertedPoint = aInsertedPoint;
        }

        public void Visit (IQuadTree aQuadTree) {
            IUserObject insertedUserObject = this.insertedPoint.GetUserObject ();
            IShape insertedShape = insertedUserObject.GetShape ();
            IRectangle targetBoundary = CalculateTargetBoundary (insertedShape);
            if (null != aQuadTree.GetRootPoints ()) {
                List<IPoint<IUserObject>> pointsToBeDeleted = new List<IPoint<IUserObject>> ();
                foreach (IPoint<IUserObject> currentPoint in aQuadTree.GetRootPoints ()) {
                    Visit (currentPoint);
                    if (currentPoint.GetUserObject ().GetHealth () < 1) {
                        pointsToBeDeleted.Add (currentPoint);
                        this.userObjectSpawner.PushBackDeadObject (currentPoint.GetUserObject ());
                    }
                    if (insertedUserObject.GetHealth () < 1) {
                        this.userObjectSpawner.PushBackDeadObject (insertedUserObject);
                        break;
                    }
                }
                aQuadTree.RemovePointsFromRoot (pointsToBeDeleted);
            }
        }

        public void SetUserObjectSpawner (IUserObjectSpawner aUserObjectSpawner) {
            this.userObjectSpawner = aUserObjectSpawner;
        }

        private void Visit (IPoint<IUserObject> aPoint) {
            IUserObject currentUserObject = aPoint.GetUserObject ();
            IShape currentShape = currentUserObject.GetShape ();
            IUserObject insertedUserObject = this.insertedPoint.GetUserObject ();
            IShape insertedShape = insertedUserObject.GetShape ();
            bool collision = CheckCollision (currentShape, insertedShape);
            if (collision) {
                insertedUserObject.TakeDamage (this.damagePoint);
                currentUserObject.TakeDamage (this.damagePoint);
                ParticleSystem particleSystem = currentUserObject.GetGameObject ().GetComponent<ParticleSystem> ();
                particleSystem.Play ();
                ChangeTransparencyAccordingToHealth (insertedUserObject);
                ChangeTransparencyAccordingToHealth (currentUserObject);
            }
        }

        private void ChangeTransparencyAccordingToHealth (IUserObject aUserObject) {
            Color objectColor = aUserObject.GetGameObject ().GetComponent<SpriteRenderer> ().material.color;
            objectColor.a = ((float) aUserObject.GetHealth ()) / aUserObject.GetInitialHealth ();
            aUserObject.GetGameObject ().GetComponent<SpriteRenderer> ().material.color = objectColor;
        }

        private bool CheckCollision (IShape currentShape, IShape insertedShape) {
            bool collision = false;
            if (typeof (ICircle).IsAssignableFrom (currentShape.GetType ())) {
                collision = insertedShape.IntersectsWithCircle ((ICircle) currentShape);
            } else if (typeof (IRectangle).IsAssignableFrom (currentShape.GetType ())) {
                collision = insertedShape.IntersectsWithRectangle ((IRectangle) currentShape);
            }
            return collision;
        }

        private IRectangle CalculateTargetBoundary (IShape aShape) {
            IRectangle targetBoundary;
            if (typeof (ICircle).IsAssignableFrom (aShape.GetType ())) {
                ICircle circleUserObject = (ICircle) aShape;
                float width = circleUserObject.GetRadius () * 2;
                targetBoundary = new Rectangle (circleUserObject.GetCenterX () - circleUserObject.GetRadius (), circleUserObject.GetCenterY () - circleUserObject.GetRadius (), width,
                    width);
            } else {
                targetBoundary = (IRectangle) aShape;
            }
            return targetBoundary;
        }

    }
}