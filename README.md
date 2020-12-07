# Conways

<img src="docs/plan.png">



#### Simplifying

My goal was to design and create a quick an simple solution to Conways Game of Life with A TDD emphasis. 

GOL is a good candidit for following Four Rules of Simple Design

- **Passes the tests**: Is functionally correct, verified through comprehensive automated tests.
- **Reveals intention**: From the readers perspective the implementation is clear and unambiguous.
- **No duplication**: Is a [DRY](https://en.wikipedia.org/wiki/Don't_repeat_yourself) implementation, with no duplicated logic.
- **Fewest elements**: If the above 3 rules are met, any other elements of the design are superfluous and candidates for simplification.(1)



The below static class Neighbourhood might be a candidit for simplification (or elimination and amalgimation into the World class.)

Is it a violation by having a extra element?

Maybe.

I abstracted/created this NeighbourHood class as part of my TDD approach. I want my GOL to be simple, clear and testable. 

I don't want to expose logic unecessarily on my world class - and when I began implementing the main business rules for this kata the first step is knowing the neighbours of a cell. 

Alternatives may be a public function on the world class that is identical - I would be able to pinpoint if it spat out wrong indexes at the cost of exposing this logic.

Another alternative is testing the behaviour of this methods side effects by looking at the results of the Tick();. This isn't ideal because I can't pinpoint if this fails as readily - and correct 'neighbour' calculation is a predicate for the application of all other business rules, so if this behaviour fails almost all other tests will - tests that are about OTHER things, like the application of the rules.

So it sits out separately - perhaps now that I have completed with TDD it should come off, but I feel like there are some strong benefits to abstracting it like this - it provides 'theoretical neighbours' based on the values put into it without exposing any other logic or data and is easily testable. 

```C#
using System.Collections.Generic;
namespace Conways
{
  public static class NeighbourHood
  {
    public static IEnumerable<RowColumn> GetNeighbourIndexes(RowColumn index, int rowDim, int colDim)
    {
      var row = index.Row;
      var column = index.Column;
      var left = column == 0 ? (colDim - 1) : (column - 1);
      var right = column == (colDim - 1) ? (0) : (column + 1);
      var up = row == 0 ? (rowDim - 1) : (row - 1);
      var down = row == (rowDim - 1) ? (0) : (row + 1);

      var neighbourHood = new HashSet<RowColumn>
      {
        new RowColumn(row, right), new RowColumn(row, left), new RowColumn(up, column), new RowColumn(down, column), new RowColumn(up, right), new RowColumn(up, left), new RowColumn(down, right), new RowColumn(down, left)
      };
      return neighbourHood;
    }
  }
}
```



#### TDD

I completed this kata (and all my recent ones as a matter of fact) with a TDD approach.

Learning to write reliable, simple unit tests has been one of the biggest educational milestones for me during acceleration. Being able to complete katas and only adding in anything that' runs' after finishing the business logic is very rewarding and gives me confidence that I understand how my data structures work (lots of katas use grids) and that my tests are in fact reliable.

unit testing is a great sprinboard to think about things like decoupling, dependencies/dependency injection and other principles we should apply in production code.

I wrote tests for all my logic before I wrote the code. GOL is a great kata for TDD and presents a clear set of business rules.

I used a combination of different types of tests.

Unit tests for logic as I needed it, and as pieces came together I'd add a new integgration test. I have tried to make sure all logic is covered by a respective unit test with dependencies provided as well as an integration test with some 'real' objects.

for instance I test the application of the 'rules' by checking the values in indexes in the grid in series of unit tests as well as visually - which also has the added benefit of being easier to understand while also testin how seperate components come together.

#### Depenency Injection

The World Class takes in its starting state in its constructor. The world doesn't need to be responsible for collecting this data, it should just be able to apply the rules. 



Simulation class is handed a IRenderer and a World.
It's single responsability is to run the simulation.





#### Decoupling

utilizing interfaces where appropriate to decouple the program from a explicitely console implementation.



references:

1) https://martinfowler.com/bliki/BeckDesignRules.html