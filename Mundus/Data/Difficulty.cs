using System;
namespace Mundus.Data {
    public static class Difficulty {
        public const int Peaceful = -5;
        public const int Easy = 0;
        public const int Normal = 10;
        public const int Hard = 40;
        public const int Insane = 200;

        public static int SelDifficulty { get; set; }
    }
}
