namespace QuadTreeSolution.Classic {
    public interface IDamageable {
        void AddHealth (int aHealth);

        int GetInitialHealth ();

        int GetHealth ();

        void TakeDamage (int aDamage);
    }
}