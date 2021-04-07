using System.Collections.Generic;
using UnityEngine;

namespace QuadTreeSolution.Classic
{

    public class DefaultUserObjectSpawner : IUserObjectSpawner {
        private int initialHealth = 5;
        private int objectUpperLimit = 1000;
        private Queue<IUserObject> deadObjectsPool = new Queue<IUserObject> ();
        private int createdObjectCount;
        private IRectangle worldBounds;
        private float radiusUpperLimit;
        private float widthUpperLimit;
        private float heightUpperLimit;

        private GameObject prefabCircle;
        private GameObject prefabRectangle;

        public DefaultUserObjectSpawner (IRectangle aWorldBounds, GameObject aPrefabCircle, GameObject aPrefabRectangle) {
            this.worldBounds = aWorldBounds;
            this.radiusUpperLimit = Mathf.Min (this.worldBounds.GetWidth (), this.worldBounds.GetHeight ()) / 100;
            this.widthUpperLimit = this.worldBounds.GetWidth () / 20;
            this.heightUpperLimit = this.worldBounds.GetHeight () / 20;
            this.prefabRectangle = aPrefabRectangle;
            this.prefabCircle = aPrefabCircle;
        }

        public void SetObjectInitialHealth (int aInitialHealth) {
            this.initialHealth = aInitialHealth;
        }

        public void SetUpperSpawnLimit (int aUpperLimit) {
            this.objectUpperLimit = aUpperLimit;
        }

        public IUserObject Spawn () {
            IUserObject spawnObject;
            if (this.deadObjectsPool.Count > 0) {
                spawnObject = this.deadObjectsPool.Dequeue ();
                int currentHealth = spawnObject.GetHealth ();
                spawnObject.AddHealth (this.initialHealth - currentHealth);
                if (typeof (IRectangle).IsAssignableFrom (spawnObject.GetShape ().GetType ())) {
                    ReSpawn ((IRectangle) spawnObject.GetShape ());
                } else if (typeof (ICircle).IsAssignableFrom (spawnObject.GetShape ().GetType ())) {
                    ReSpawn ((ICircle) spawnObject.GetShape ());
                }
            } else if (this.createdObjectCount >= this.objectUpperLimit) {
                throw new OverLimitSpawnException (this.createdObjectCount, this.objectUpperLimit);
            } else {
                IShape shape;
                GameObject gameObject;
                if (this.createdObjectCount % 2 == 0) {
                    shape = SpawnCircle ();
                    gameObject = MonoBehaviour.Instantiate (prefabCircle, new Vector3 (shape.GetCenterX (), shape.GetCenterY (), 0), Quaternion.identity);
                } else {
                    shape = SpawnRectangle ();
                    gameObject = MonoBehaviour.Instantiate (prefabRectangle, new Vector3 (shape.GetCenterX (), shape.GetCenterY (), 0), Quaternion.identity);
                }
                spawnObject = new UserObject (this.initialHealth, shape, gameObject);
                this.createdObjectCount++;
            }

            Color objectColor = spawnObject.GetGameObject ().GetComponent<SpriteRenderer> ().material.color;
            objectColor.a = 1f;
            ResizeSprite (spawnObject);
            spawnObject.GetGameObject ().SetActive (true);
            return spawnObject;
        }

        private void ResizeSprite (IUserObject aUserObject) {
            GameObject gameObject = aUserObject.GetGameObject ();
            RectTransform rectTransform = gameObject.GetComponent<RectTransform> ();
            IShape shape = aUserObject.GetShape ();
            float newWidth = 1f;
            float newHeight = 1f;
            if (typeof (IRectangle).IsAssignableFrom (aUserObject.GetShape ().GetType ())) {
                newWidth = ((IRectangle) shape).GetWidth ();
                newHeight = ((IRectangle) shape).GetHeight ();
            } else if (typeof (ICircle).IsAssignableFrom (aUserObject.GetShape ().GetType ())) {
                newWidth = 2 * ((ICircle) shape).GetRadius ();
                newHeight = newWidth;
            }
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
            Vector3 localScale = rectTransform.localScale;
            localScale.x = newWidth / spriteRenderer.sprite.bounds.size.x;
            localScale.y = newHeight / spriteRenderer.sprite.bounds.size.y;
            rectTransform.localScale = localScale;
        }

        private IRectangle SpawnRectangle () {
            IRectangle rectangle = new Rectangle ();
            ReSpawn (rectangle);
            return rectangle;
        }

        private void ReSpawn (IRectangle aRectangle) {
            aRectangle.SetX (Random.Range (1f, this.worldBounds.GetWidth ()) + this.worldBounds.GetX ());
            aRectangle.SetY (Random.Range (1f, this.worldBounds.GetHeight ()) + this.worldBounds.GetY ());
            aRectangle.SetWidth (Random.Range (10f, this.widthUpperLimit));
            aRectangle.SetHeight (Random.Range (10f, this.heightUpperLimit));
        }

        private ICircle SpawnCircle () {
            ICircle circle = new Circle ();
            ReSpawn (circle);
            return circle;
        }

        private void ReSpawn (ICircle aCircle) {
            aCircle.SetRadius (Random.Range (5f, this.radiusUpperLimit));
            aCircle.SetCenterX (Random.Range (1f, this.worldBounds.GetWidth ()) + this.worldBounds.GetX ());
            aCircle.SetCenterY (Random.Range (1f, this.worldBounds.GetHeight ()) + this.worldBounds.GetY ());
        }

        public void PushBackDeadObject (IUserObject aUserObject) {
            aUserObject.GetGameObject ().SetActive (false);
            this.deadObjectsPool.Enqueue (aUserObject);
        }

    }
}