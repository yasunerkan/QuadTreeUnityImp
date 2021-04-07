namespace QuadTreeSolution.Classic {
    public interface IUserObjectSpawner {
        void SetObjectInitialHealth (int aInitialHealth);

        void SetUpperSpawnLimit (int aUpperLimit);

        IUserObject Spawn ();

        void PushBackDeadObject (IUserObject aUserObject);
    }
}