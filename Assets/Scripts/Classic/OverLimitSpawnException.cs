using System;
namespace QuadTreeSolution.Classic {
    public class OverLimitSpawnException : Exception {
        public OverLimitSpawnException (int aCreatedObjectCount, int aUpperLimit) : base ("Created object count (" + aCreatedObjectCount + ") is greater equal to upper limit (" + aUpperLimit + ")") { }

    }
}