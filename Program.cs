using System;


//this implement the player class
public class Player
{

    private string playerName;
    private string playerId;
    private int score;

    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value; 
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if (value >=0)
            {
                score = value;
            }
        }
    }

    public Player(string playerName, string playerId)
    {
        this.playerName = playerName;
        this .playerId = playerId;
        this.score = 0;
    }

    public void showinfo()
    {
        Console.WriteLine("Player Name : " + playerName);
        Console.WriteLine("Player ID   : " + playerId);
        Console.WriteLine("Score       : " + score);
    }
    public void AddScore(int points)
    {
        score += points;
        Console.WriteLine(playerName + " earned " + points + " points! Total: " + score);
    }
}


// this part is to implement the card class
public class Card
{
    private int cardID;
    private string rank;
    private bool flipped;
    private bool matched;

    public int CardID
    {
        get
        {
            return cardID;
        }
    }
    
    public bool Flipped
    {
        get
        {
            return flipped;
        }
    }

    public bool Matched
    {
        get
        {
            return matched;
        }
    }

    public Card ( int cardID, string rank)
    {
        this.cardID = cardID;
        this.rank = rank;
        this.flipped = false;
        this.matched = false;
    }

    public string getrank()
    {
        return rank;
    }

    public void flip()
    {
        flipped = !flipped;

        Console.WriteLine("Card " + cardID + " (" + rank + ") is now " + (flipped ? "face up" : "face down"));
    }

    public void Match()
    {
        matched = true;
        flipped = true;
        Console.WriteLine("Card " + cardID + " (" + rank + ") is matched!");
    }

    public void Reset()
    {
        flipped = false;
        matched = false;
        Console.WriteLine("Card " + cardID + " has been reset.");
    }
}


// this section is to implement score class
public class Score
{
    
    private int currentScore;
    private int matchPoint;
    private int penaltyPoint;

    
    public int CurrentScore
    {
        get 
        { 
            return currentScore;
        }
    }

    public int MatchPoint
    {
        get 
        { 
            return matchPoint; 
        }
        set 
        { 
            matchPoint = value;
        }
    }

    public int PenaltyPoint
    {
        get 
        { 
            return penaltyPoint; 
        }
        set 
        {
            penaltyPoint = value; 
        }
    }

   
    public Score(int matchPoint, int penaltyPoint)
    {
        this.currentScore = 0;
        this.matchPoint = matchPoint;
        this.penaltyPoint = penaltyPoint;
    }

    
    public void AddPoints()
    {
        currentScore += matchPoint;
        Console.WriteLine("Match! +" + matchPoint + " points. Total: " + currentScore);
    }

    public void deductPenalty()
    {
        currentScore -= penaltyPoint;
        if (currentScore < 0) currentScore = 0;
        Console.WriteLine("Penalty! -" + penaltyPoint + " points. Total: " + currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        Console.WriteLine("Score reset to 0.");
    }

    public int GetScore()
    {
        return currentScore;
    }
}


//start of the main program
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Memory Card Game ===\n");

        //creates object 
        Player player = new Player("Faris", "P1");
        Score score = new Score(10, 2);
        Card card1 = new Card(1, "Heart");
        Card card2 = new Card(2, "Heart");
        Card card3 = new Card(3, "Diamond");
        Card card4 = new Card(4, "Spade");

        
        player.showinfo();
        Console.WriteLine();

        
        Console.WriteLine("--- Turn 1: flip same card rank --- ");
        card1.flip();
        card2.flip();

        if (card1.getrank() == card2.getrank())
        {
            card1.Match();
            card2.Match();
            score.AddPoints();
            
        }
        Console.WriteLine();

        
        Console.WriteLine("--- Turn 2: Flip different card rank ---  ");
        card3.flip();
        card4.flip();

        if (card3.getrank() != card4.getrank())
        {
            Console.WriteLine("No match! Flipping cards back down.");
            card3.Reset();
            card4.Reset();
            score.deductPenalty();
        }
        Console.WriteLine();

        
        Console.WriteLine("=== Game Over ===");
        player.showinfo();
        Console.WriteLine("Final Score : " + score.GetScore());
    }
}