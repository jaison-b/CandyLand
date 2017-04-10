using System.Collections.Generic;
using System.Linq;

public class BoardSpace
{
    public CandyColor Color { get; set; }
    public int Position { get; set; }
    public bool IsLicorice { get; set; }
    public int? ShortcutDestination { get; set; }
}

public static class Extensions
{
    public static BoardSpace GetMatchingSpace(this List<BoardSpace> spaces, int currentIndex, Card card)
    {
        //handle specialty card
        if (card.IsSpecialty())
        {
            var specialtyCardMatches = spaces.Where(space => space.Color == card.Color);
            return specialtyCardMatches.First();
        }

        //handle regular card
        var matchedIndex = spaces.FindIndex(currentIndex + 1, space => space.Color == card.Color);
        if (matchedIndex > -1)
        {
            return spaces[matchedIndex];
        }
        //reached the end
        return new BoardSpace() { Color = CandyColor.Rainbow, Position = 133 };

    }
}