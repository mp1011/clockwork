using System;

namespace Clockwork.Engine.Models.General
{

    [Flags]
    public enum BorderSide
    {
        None = 0,
        Left = 1,
        Top = 2,
        Right = 4,
        Bottom = 8,
        AllSides = 15,
        TopLeftCorner = 16,
        TopRightCorner = 32,
        BottomLeftCorner = 64,
        BottomRightCorner = 128,
        AllSidesAndCorners = 256,
        AllCorners = TopLeftCorner + TopRightCorner + BottomLeftCorner + BottomRightCorner,
        EmptySpace = 512,
        NotTopLeftCorner = TopRightCorner + BottomLeftCorner + BottomRightCorner,
        NotTopRightCorner = TopLeftCorner + BottomLeftCorner + BottomRightCorner,
        NotBottomLeftCorner = TopRightCorner + BottomRightCorner + TopLeftCorner,
        NotBottomRightCorner = TopLeftCorner + TopRightCorner + BottomLeftCorner
    }
}
