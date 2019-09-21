namespace Common.Entities
{
    public class GameScreen
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public GameScreen(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}