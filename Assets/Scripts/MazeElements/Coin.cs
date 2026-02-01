using UnityEngine;

namespace MazeElements
{
    internal sealed class Coin : MonoBehaviour
    {
        private const int CoinValue = 1;

        public int Value => CoinValue;
    }
}