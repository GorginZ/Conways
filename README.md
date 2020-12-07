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

Is it a violation - by having a extra element?

Maybe.

I abstracted/created this NeighbourHood class as part of my TDD approach. I want my GOL to be simple, clear and testable. 

I didn't want to expose logic unecessarily on my world class - and a prerequisite for the main logic in the world class is locating neighbours of a cell.

Alternatives may be a public function on the world class that is identical - I would be able to pinpoint if it spat out wrong indexes at the cost of exposing this logic.

Another alternative is testing the behaviour of this methods side effects by looking at the results of the Tick();. This isn't ideal because I can't pinpoint if this fails as readily - and correct 'neighbour' calculation is a predicate for the application of all other business rules, so if this behaviour fails almost all other tests will - tests that are about OTHER things, like the application of the rules.

So it sits out separately - perhaps now that I have completed with TDD it should come off, but I feel like there are some convincing benefits to abstracting it like this - it provides 'theoretical neighbours' based on the values put into it without exposing any other logic or data and is easily testable. 

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

Learning to write reliable, simple unit tests has been one of the biggest educational milestones for me during acceleration. Being able to complete katas and only adding in anything that' runs' after finishing the business logic is very rewarding and gives me confidence that I understand how my data structures work  and that my tests are in fact reliable.

unit testing is a great sprinboard to think about things like decoupling, dependencies/dependency injection and other principles we should apply in production code.

for instance when I'm writing tests for how my console Renderer decides to render the data I need to think about the simplest way to give it that data and the simplest piece of data to test as a response. 


Writing the tests is where I decided to make decisions about who would be responsible for how the grid is rendered. 

I decided I didn't want the world to be responsible for spitting out a grid as a string because the world as a domain is very succinct and explicit in what it does - it applies the tick rules, and providing the grid as a string is only ever going to be for rendering it in a console. So I don't want this logic in my world class.

I made a IRender, which would take in a 'raw' grid and decide how to display that. The ConsoleRenderer takes in a Cellstate[,] and decides what to do with it. 

taking in a cellstate is preferable to for instance the entire world - all it needs is the grid. But I also did not want to expose the grid unecessarily, so the world provides a clone of its grid.



My tests check it renders it correctly from a raw dummy input (below).

<img src="docs/rawGrid.png">



And a seperate integration type test which utilizes a 'real' grid.

<img src="docs/gridClassDependent.png">

I wrote tests for all my logic before I wrote the code. GOL is a great kata for TDD and presents a clear set of business rules and the TDD approach helped me make better design decisions as I worked through each problem in small bite sizes  and help me missing any details I might overlook from a big picture approach coming into it. 

for instance I test the application of the 'rules' by checking the values in indexes in the grid in series of unit tests as well as visually - which also has the added benefit of being easier to understand while also testin how seperate components come together.

#### Depenency Injection

The World Class takes in its starting state in its constructor. The world doesn't need to be responsible for collecting this data, it should just be able to apply the rules. There is no need for its state ot be set externaly at any point so my world class is designed with this in mind.

Simulation class is handed a IRenderer and a World.
It's single responsability is to run the simulation, similarly it should not need any external input  except maybe to cease the simulation.

#### Decoupling

I have done my best to keep my classes designed such that all of their dependencies are handed to them

removing dependencies on console

utilizing interfaces where appropriate to decouple the program from a explicitely console implementation, for instance all the set up arguments are returned from a ConsoleInput which implements IRead, which is passed into a world ready to go.



references:

1) https://martinfowler.com/bliki/BeckDesignRules.html