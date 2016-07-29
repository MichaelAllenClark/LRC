# Example of using C# to simulate games of Left, Right, Center

## Rules (As I understand them)
- Each player starts with 3 tokens (which could be dollar bills)
- Players arrange themselves in a circle
- Pick one player to start, that person rolls a die up to a maximum of 3 times, once for each token they have at the start of their turn. 
  * The die is 6 sided where one side represents left, one right, and one center.  The rest indicate no action. 
  * If token lands on left/right, the player passes a token to the player in that direction. 
  * If token lands on center, player puts token in the center(pot). 
  * If token lands on no action (safe), do nothing. 
- After all die rolls, turn moves to the next player in the circle. 
- If a player has zero tokens, they stay in the game but don't roll a die on their turn but are eligible to receive tokens from the players to their sides so could potentially win or roll again.  
- The game ends when only a single player has any tokens left, the player with the remaining token(s) is the winner. 

## Midly Interesting findings
1. Don't worry if you run out of tokens. If you are playing with 5 players, there is a ~75% chance that the one who ends up winning will have zero at some point.  The more players, the greater the chances that the winner will have zero at some point.  
2. You want to be the last (or close to last) to roll for a slight increase in chance of winning. As the number of players increases, this benefit diminishes. 
3. Similar to the first item on the list, don't get too excited if you have a large stack of tokens.  Odds are the person with the most tokens doesn't end up winning.   

## Example Output:
	For 3 players with 1000000 iterations
	Average Number of Turns: 18.851406
	Average Number of Tokens at end: 2.5986
	Chances of returning from zero: 42.1640%
	Chances of losing even if you had the most tokens at some point: 56.1143%
	Chances of winning if player: 0 are 30.737%, Diff: -2.5967%
	Chances of winning if player: 1 are 32.805%, Diff: -0.5283%
	Chances of winning if player: 2 are 36.458%, Diff: 3.1251%
	Highest Chance of Winning is position: 3
	For 4 players with 1000000 iterations
	Average Number of Turns: 33.934878
	Average Number of Tokens at end: 2.0444
	Chances of returning from zero: 63.8483%
	Chances of losing even if you had the most tokens at some point: 68.6390%
	Chances of winning if player: 0 are 23.875%, Diff: -1.1252%
	Chances of winning if player: 1 are 24.322%, Diff: -0.6778%
	Chances of winning if player: 2 are 25.512%, Diff: 0.5120%
	Chances of winning if player: 3 are 26.291%, Diff: 1.2910%
	Highest Chance of Winning is position: 4
	For 5 players with 1000000 iterations
	Average Number of Turns: 49.942567
	Average Number of Tokens at end: 1.7490
	Chances of returning from zero: 75.1766%
	Chances of losing even if you had the most tokens at some point: 75.6587%
	Chances of winning if player: 0 are 19.423%, Diff: -0.5774%
	Chances of winning if player: 1 are 19.433%, Diff: -0.5672%
	Chances of winning if player: 2 are 19.962%, Diff: -0.0377%
	Chances of winning if player: 3 are 20.589%, Diff: 0.5885%
	Chances of winning if player: 4 are 20.594%, Diff: 0.5938%
	Highest Chance of Winning is position: 5
	For 6 players with 1000000 iterations
	Average Number of Turns: 66.633943
	Average Number of Tokens at end: 1.5754
	Chances of returning from zero: 81.4631%
	Chances of losing even if you had the most tokens at some point: 79.8978%
	Chances of winning if player: 0 are 16.266%, Diff: -0.4009%
	Chances of winning if player: 1 are 16.132%, Diff: -0.5352%
	Chances of winning if player: 2 are 16.428%, Diff: -0.2389%
	Chances of winning if player: 3 are 16.912%, Diff: 0.2455%
	Chances of winning if player: 4 are 17.252%, Diff: 0.5855%
	Chances of winning if player: 5 are 17.011%, Diff: 0.3438%
	Highest Chance of Winning is position: 5
	For 7 players with 1000000 iterations
	Average Number of Turns: 83.976049
	Average Number of Tokens at end: 1.4642
	Chances of returning from zero: 85.6622%
	Chances of losing even if you had the most tokens at some point: 82.8946%
	Chances of winning if player: 0 are 13.874%, Diff: -0.4122%
	Chances of winning if player: 1 are 13.793%, Diff: -0.4923%
	Chances of winning if player: 2 are 13.979%, Diff: -0.3064%
	Chances of winning if player: 3 are 14.363%, Diff: 0.0772%
	Chances of winning if player: 4 are 14.624%, Diff: 0.3381%
	Chances of winning if player: 5 are 14.837%, Diff: 0.5510%
	Chances of winning if player: 6 are 14.530%, Diff: 0.2447%
	Highest Chance of Winning is position: 6
	For 8 players with 1000000 iterations
	Average Number of Turns: 101.900715
	Average Number of Tokens at end: 1.3877
	Chances of returning from zero: 88.4962%
	Chances of losing even if you had the most tokens at some point: 85.0927%
	Chances of winning if player: 0 are 12.245%, Diff: -0.2552%
	Chances of winning if player: 1 are 12.004%, Diff: -0.4960%
	Chances of winning if player: 2 are 12.169%, Diff: -0.3313%
	Chances of winning if player: 3 are 12.270%, Diff: -0.2301%
	Chances of winning if player: 4 are 12.684%, Diff: 0.1835%
	Chances of winning if player: 5 are 12.956%, Diff: 0.4557%
	Chances of winning if player: 6 are 12.974%, Diff: 0.4743%
	Chances of winning if player: 7 are 12.699%, Diff: 0.1991%
	Highest Chance of Winning is position: 7
	For 9 players with 1000000 iterations
	Average Number of Turns: 120.222034
	Average Number of Tokens at end: 1.3324
	Chances of returning from zero: 90.5421%
	Chances of losing even if you had the most tokens at some point: 86.6946%
	Chances of winning if player: 0 are 10.841%, Diff: -0.2699%
	Chances of winning if player: 1 are 10.637%, Diff: -0.4739%
	Chances of winning if player: 2 are 10.692%, Diff: -0.4190%
	Chances of winning if player: 3 are 10.871%, Diff: -0.2399%
	Chances of winning if player: 4 are 11.167%, Diff: 0.0557%
	Chances of winning if player: 5 are 11.397%, Diff: 0.2855%
	Chances of winning if player: 6 are 11.534%, Diff: 0.4230%
	Chances of winning if player: 7 are 11.598%, Diff: 0.4873%
	Chances of winning if player: 8 are 11.262%, Diff: 0.1513%
	Highest Chance of Winning is position: 8
	For 10 players with 1000000 iterations
	Average Number of Turns: 139.156567
	Average Number of Tokens at end: 1.2906
	Chances of returning from zero: 92.0421%
	Chances of losing even if you had the most tokens at some point: 87.9668%
	Chances of winning if player: 0 are 9.811%, Diff: -0.1888%
	Chances of winning if player: 1 are 9.500%, Diff: -0.5005%
	Chances of winning if player: 2 are 9.642%, Diff: -0.3582%
	Chances of winning if player: 3 are 9.718%, Diff: -0.2820%
	Chances of winning if player: 4 are 9.912%, Diff: -0.0879%
	Chances of winning if player: 5 are 10.091%, Diff: 0.0905%
	Chances of winning if player: 6 are 10.303%, Diff: 0.3029%
	Chances of winning if player: 7 are 10.458%, Diff: 0.4582%
	Chances of winning if player: 8 are 10.392%, Diff: 0.3917%
	Chances of winning if player: 9 are 10.174%, Diff: 0.1741%
	Highest Chance of Winning is position: 8
	For 11 players with 1000000 iterations
	Average Number of Turns: 158.364391
	Average Number of Tokens at end: 1.2586
	Chances of returning from zero: 93.1847%
	Chances of losing even if you had the most tokens at some point: 89.0373%
	Chances of winning if player: 0 are 8.923%, Diff: -0.1682%
	Chances of winning if player: 1 are 8.688%, Diff: -0.4027%
	Chances of winning if player: 2 are 8.684%, Diff: -0.4068%
	Chances of winning if player: 3 are 8.760%, Diff: -0.3312%
	Chances of winning if player: 4 are 8.954%, Diff: -0.1368%
	Chances of winning if player: 5 are 9.080%, Diff: -0.0105%
	Chances of winning if player: 6 are 9.296%, Diff: 0.2051%
	Chances of winning if player: 7 are 9.442%, Diff: 0.3514%
	Chances of winning if player: 8 are 9.522%, Diff: 0.4309%
	Chances of winning if player: 9 are 9.458%, Diff: 0.3675%
	Chances of winning if player: 10 are 9.192%, Diff: 0.1014%
	Highest Chance of Winning is position: 9
	For 12 players with 1000000 iterations
	Average Number of Turns: 178.145398
	Average Number of Tokens at end: 1.2325
	Chances of returning from zero: 94.0968%
	Chances of losing even if you had the most tokens at some point: 89.9134%
	Chances of winning if player: 0 are 8.057%, Diff: -0.2765%
	Chances of winning if player: 1 are 7.963%, Diff: -0.3703%
	Chances of winning if player: 2 are 7.933%, Diff: -0.4003%
	Chances of winning if player: 3 are 8.034%, Diff: -0.2993%
	Chances of winning if player: 4 are 8.156%, Diff: -0.1771%
	Chances of winning if player: 5 are 8.282%, Diff: -0.0509%
	Chances of winning if player: 6 are 8.401%, Diff: 0.0672%
	Chances of winning if player: 7 are 8.589%, Diff: 0.2555%
	Chances of winning if player: 8 are 8.698%, Diff: 0.3646%
	Chances of winning if player: 9 are 8.799%, Diff: 0.4655%
	Chances of winning if player: 10 are 8.666%, Diff: 0.3327%
	Chances of winning if player: 11 are 8.423%, Diff: 0.0893%
	Highest Chance of Winning is position: 10
	Done



