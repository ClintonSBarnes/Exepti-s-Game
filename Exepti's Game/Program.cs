//establishes required variables
Random random = new Random();
int oatmealCookieNumber = random.Next(0, 10);
int player1Guess;
int player2Guess;
int turnTracker = 1;
int currentGuess = -1;
List<int> previousGuesses = new List<int>();
bool playing = true;

//initializes and welcomes players to the game.
Console.Write("Press any key to roll the 10 sided die to determine which cookie is Oatmeal Rasin:  ");
Console.ReadKey();
Console.Clear();

while (playing == true) //holds game open until "wrong" guess has been committed by one of the players.
{
    PlayerGuess();//calls the player's guess intake method.

    for (int i = 0; i < previousGuesses.Count; i++)//searches the previousGuess<> list for a previously selected item.
    {
        if (previousGuesses[i] == currentGuess)
        {
            Console.WriteLine("That number has already been selected. You will need to select again.");
            PlayerGuess();
        }
    }

    try//this is the exception practice called for by the task in C# Player's Guide
    {
        if (currentGuess == oatmealCookieNumber) throw new Exception();

    }
    catch (Exception) //this is the catch, but is used as a game termination point too
    {
        Console.WriteLine("You have selected the Oatmeal cookie. You spit the bite out in disgust and accept that you are a loser. GAME OVER.");
        playing = false;
    }

    if (currentGuess != oatmealCookieNumber)
    {
        previousGuesses.Add(currentGuess);
        Console.WriteLine("You have choosen wisely, and you get to enjoy a man's cookie...a chocolate chip cookie.");

        //changes the turn between each player
        if (turnTracker == 1)
        {
            turnTracker = 2;
        }
        else if (turnTracker == 2)
        {
            turnTracker = 1;
        }


    }
}

void PlayerGuess() //This method will intake the player's guess, assign the guess to the player's guess variable, and will adjust the turn tracker in preparation for the next turn.
{
    Console.Write($"Player {turnTracker}: Enter your cookie selection: ");

    //this could incorporate error handling, but it is not called for within the task objectives. 
    if (turnTracker == 1)
    {
        player1Guess = Convert.ToInt16(Console.ReadLine());
        currentGuess = player1Guess;
    }
    else
    {
        player2Guess = Convert.ToInt16(Console.ReadLine());
        currentGuess = player2Guess;
    }
}



