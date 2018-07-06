namespace AgarNetPlugin
{
    class Player
    {
        public ushort Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Size { get; set; }
        public byte ColorR { get; set; }
        public byte ColorG { get; set; }
        public byte ColorB { get; set; }

        public Player(ushort id, float x, float y, float size, byte colorR, byte colorG, byte colorB)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.Size = size;
            this.ColorR = colorR;
            this.ColorG = colorG;
            this.ColorB = colorB;
        }
    }
}
