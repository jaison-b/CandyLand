public class Player
{
    public string Name { get; set; }
    public int CurrentLocation { get; set; }
    public int Order { get; set; }
    public bool IsSkipped { get; set; }
    public bool IsWinner { get; set; }

    public string TakeTurn(Board board, CardDeck deck)
    {
        if (IsSkipped)
        {
            IsSkipped = false;
            return Name + " was skipped";
        }
        var card = deck.Draw();
        var newSpace = board.Spaces.GetMatchingSpace(CurrentLocation, card);
        CurrentLocation = newSpace.Position;
        string msg = Name + " moved to Space " + CurrentLocation + " which is a " + newSpace.Color + " space.";

        if (newSpace.IsLicorice)
        {
            IsSkipped = true;
            msg += Name + "is stuck by Licorice!";
        }

        if (newSpace.ShortcutDestination.HasValue)
        {
            CurrentLocation = newSpace.ShortcutDestination.Value;
            msg += Name + " took a shortcut to Space " + CurrentLocation + "!";
        }

        if (CurrentLocation == 133)
        {
            IsWinner = true;
            msg += Name + " won the game!";
        }
        return msg;
    }
}