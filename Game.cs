using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;

namespace LRC
{
    class Game
    {
        public int CurrentTurn { get; private set; }
        public int? LastTurn { get; private set; }
        private Dictionary<int, string> Dice = new Dictionary<int, string>();
        public Int16 Pot { get; private set; }
        public List<Player> Players { get; private set; }
        public Player Winner { get; internal set; }
        public Int16 StartingTokens { get; private set; }
        public Int16 NumberOfTurns { get; private set; }
        public Int16? HighestTokenCount { get; private set; }
        public Int16? HighestTokenPlayerID { get; private set; }
        private Random rnd;

        public int RollDie() {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] onebyte = new byte[1];
            do
            {
                crypto.GetBytes(onebyte);
                int randomint = onebyte[0];
                if (randomint < 252)
                    return (randomint % 6) + 1;
            }
            while (true);
        }


        public Game(Int16 NumberOfPlayers, Int16 NumberOfTokens)
        {
            Players = new List<Player>();
            StartingTokens = NumberOfTokens;
            for (Int16 p = 0; p < NumberOfPlayers; p += 1)
                Players.Add(new Player(NumberOfTokens, p));
            // Assign values to the die rolls
            Dice.Add(1, "Left");
            Dice.Add(2, "Right");
            Dice.Add(3, "Center");
            Dice.Add(4, "Safe");
            Dice.Add(5, "Safe");
            Dice.Add(6, "Safe");
            // Set the starting player to number 0
            CurrentTurn = 0;
            LastTurn = null;
            Pot = 0;
            NumberOfTurns = 0;
            rnd = new Random();
        }

        // Left and Right is based on players being setup clockwise
        internal int RightPlayer() {
            if (CurrentTurn == 0)
                return Players.Count - 1;
            else
                return CurrentTurn - 1;
        }

        internal int LeftPlayer()
        {
            if (CurrentTurn == Players.Count - 1)
                return 0;
            else
                return CurrentTurn + 1;
        }

        private void AddToPot()
        {
            Pot += 1;
        }

        public Player CurrentPlayer() {
            return Players[CurrentTurn];
        }

        public Player LastPlayer()
        {
            return Players[RightPlayer()];
        }

        public bool PlayNextTurn() {
            NumberOfTurns += 1;
            // If they have more than the starting amount (usually 3) then that is the maximum number of rolls, otherwhise it is based on current number of tokens
            for (Int16 p = ((Players[CurrentTurn].NumberOfTokens > StartingTokens) ? StartingTokens : Players[CurrentTurn].NumberOfTokens); p >= 1; p -= 1) {



                int CurrentRole = this.RollDie();
                switch (Dice[CurrentRole])
                {
                    case "Left":
                        Players[CurrentTurn].Subtract();
                        Players[LeftPlayer()].Add();
                        break;
                    case "Right":
                        Players[CurrentTurn].Subtract();
                        Players[RightPlayer()].Add();
                        break;
                    case "Center":
                        Players[CurrentTurn].Subtract();
                        this.AddToPot();
                        break;
                    case "Safe":
                        break;
                }
            }

            // Check for winner by seeing if anyone has all of the money not in the pot
            for (int p = 0; p < Players.Count; p++)
            {
                // Check their tokens to see if they have the token count before the game starts
                if ((HighestTokenCount == null || HighestTokenPlayerID == null) || Players[CurrentTurn].NumberOfTokens > HighestTokenCount)
                {
                    HighestTokenCount = Players[CurrentTurn].NumberOfTokens;
                    HighestTokenPlayerID = Players[CurrentTurn].PlayerID;
                }

                if (Players[p].NumberOfTokens + Pot == (StartingTokens * Players.Count))
                {
                    Winner = Players[p];
                    return true;
                }
            }

            LastTurn = CurrentTurn;
            CurrentTurn = LeftPlayer();
            return false;                
        }
    }

    class Player
    {
        public Int16 PlayerID {get; internal set;}
        public Player(Int16 Tokens, Int16 ID)
        {
            LowestTokens = Tokens;
            NumberOfTokens = Tokens;
            PlayerID = ID;
        }
        public Int16 NumberOfTokens { get; internal set;}
        public Int16 LowestTokens { get; internal set; }

        internal void Subtract() {
            NumberOfTokens -= 1;
            if (NumberOfTokens < LowestTokens)
                LowestTokens = NumberOfTokens;
        }
        internal void Add()
        {
            NumberOfTokens += 1;            
        }
    }
}
