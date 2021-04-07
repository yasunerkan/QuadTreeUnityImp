using System.Collections;
using UnityEditor;
using UnityEngine;

namespace QuadTreeSolution.Classic {

    public class QuadTreeManager : MonoBehaviour {
        private IQuadTree quadTree;

        private IUserObjectSpawner userObjectSpawner;

        private InsertQuadTreeVisitor insertQuadTreeVisitor;
        private IQuadTreeVisitor debugRenderingQuadTreeVisitor;

        private bool suitableForSpawn = false;

        private WaitForSecondsRealtime waitForObjectCreation;
        public float objectCreatePeriod = 0.025f;
        private Coroutine spawnCoroutine;

        public GameObject prefabCircle;
        public GameObject prefabRectangle;

        void Awake () {
            Init ();
        }

        void Init () {
            waitForObjectCreation = new WaitForSecondsRealtime (objectCreatePeriod);
            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;
            IRectangle boundary = new Rectangle (-width / 2, -height / 2, width, height);
            quadTree = new QuadTree (4, boundary);
            userObjectSpawner = new DefaultUserObjectSpawner (boundary, prefabCircle, prefabRectangle);
            insertQuadTreeVisitor = new InsertQuadTreeVisitor (1, userObjectSpawner);
            debugRenderingQuadTreeVisitor = new DebugRenderingQuadTreeVisitor ();
            userObjectSpawner.SetUpperSpawnLimit (PlayerPrefs.GetInt ("NumberOfEntities"));
            userObjectSpawner.SetObjectInitialHealth (PlayerPrefs.GetInt ("InitialHealth"));
            suitableForSpawn = true;
            Selection.activeGameObject = gameObject;
        }

        private void OnSceneGUI () { }

        public void OnDrawGizmos () {
            if (null != debugRenderingQuadTreeVisitor)
                quadTree.Accept (debugRenderingQuadTreeVisitor);
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable () {
            spawnCoroutine = StartCoroutine (Spawn ());
        }

        // This function is called when the behaviour becomes disabled or inactive
        private void OnDisable () {
            if (null != spawnCoroutine)
                StopCoroutine (spawnCoroutine);
        }

        private IEnumerator Spawn () {
            while (suitableForSpawn) {
                try {
                    IUserObject userObject = userObjectSpawner.Spawn ();
                    IPoint<IUserObject> point = new Point<IUserObject> (userObject.GetShape ().GetCenterX (), userObject.GetShape ().GetCenterY (), userObject);
                    insertQuadTreeVisitor.SetInsertedPoint (point);
                    quadTree.Insert (point, insertQuadTreeVisitor);
                } catch (OverLimitSpawnException exception) {
                    suitableForSpawn = false;
                    Debug.Log (exception);
                    EditorUtility.DisplayDialog ("Info", exception.Message, "OK");
                }
                yield return waitForObjectCreation;
            }
        }

    }
}