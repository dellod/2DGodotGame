using Godot;
using System;

public partial class GameManager : Node
{
    public int Score { get; private set; } = 0;

    public void AddScore(int points)
    {
        Score += points;
        Label scoreLabel = GetNode<Label>("%ScoreLabel");
        scoreLabel.Text = $"You collected {Score} Coins";
    }
}
