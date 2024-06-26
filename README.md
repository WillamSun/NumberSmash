# Number Smash, a simple number game

![Icon](./img/title.png)

## Interface

![Interface](./img/interface.png)

*Top: Menu Strip*

*Buttom: Controls*

*Middle: Equation with 7 numbers*

*Right: 3 counters*

## Rules

The objective of the game is to select a set of numbers that add up to 0. When the game begins, it will present you with an equation containing 7 numbers. Your goal is to select one or more numbers from the equation that, when added together, equal 0.

To play, simply click on the numbers you want to select. As long as the sum of the selected numbers is 0, you will earn 1 point and the equation will be refreshed with a new set of 7 numbers. If the sum of your selected numbers does not equal 0, you will lose the game.

![Example1](./img/example1.png)

*Example 1, showing -7 and 7 been selected*

The above is an example of selecting two numbers that have a sum of 0.

![Example2](./img/example2.png)

*Example 2, showing only selecting 0*

Single 0 is also OK.

If you are unable to find a set of numbers that add up to 0, you can click the "Refresh" button to generate a new equation. The game will check if there is a valid solution before refreshing.

To restart the game at any time, click the "Reset" button. You can also click the "Help" button to have the game automatically find a set of numbers that add up to 0.

Additionally, the game includes several optional advanced features that can enhance the experience:

- "Select All" checkbox to instantly select or deselect all numbers
- "Pause" checkbox to pause the game 
- Counters that displays your score and time used
- Options to adjust font size, make the game always on top, show a progress bar, and display the current sum

More options can be found on the menu strip at the top.

There are also several special number types that can be introduced by enabling the "Extended Features Toggle":

- Infinitive (∞) - Can be combined with any other number, but does not count towards your score
- Signum (±) - Represents both positive and negative versions of a number
- Unknown (x) - Allows you to avoid losing a point one time if the sum is not 0
- Double ([×2]) - Doubles your score when used
- Null - Refreshes the equation without resetting the game
- Multiplication of 0 ([×0]) - Same as Infinitive, but counts towards your score

![Example3](./img/example3.png)

*Example 3, showing multiple special numbers appearing in one equation*

In the above example, the Infinitive can smash with any number, and by selecting the Double with 0, you can get two points.

## Releases

There are two different releases of this game:

- Release: Presents everything
- Without BSoD Release: Removed the "BSoD After Losing" options

## Credits

Presented by Idad Wind  
Enjoy :)

## License

MIT License

Copyright (c) 2024 Idad Wind

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.