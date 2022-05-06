<!-- PROJECT LOGO -->
<br />
<div align="center">
  

<h3 align="center">Word Ladder Challange</h3>

  <p align="center">
    A simple exercise to solve the Word Ladder problem
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
    </li>
    <li><a href="#word-ladder-solvers">Word Ladder Solvers</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

The main idea was to solve the Word Ladder problem in a fresh take without base myself in other solutions.

After reading the problem the first thing I thought of to solve this was using a graph in order to find the shortest path between two words, but then I questionned myself if it was not too much and did a litle POC without graphs to see if I could solve this using more simple structures.
Alas, after some tries I reallized that without a graph I would not know which was the shortest path without ending up with even more complex code.

Realizing this I went back to the original thought and start tackling the technical details for my application. I decided to use an DDD (Domain Driven Development) approach to keep my code clean and reusable, avoiding couple my solution to the infrastructure and improve the isolation of concepts:

![Architecture_Diagram](/arch.drawio.png?raw=true "Architecture Diagram")

* In the Domain I can create the models that represents the problem at hands and define how will it be loaded without consern on how the problem will be solved
* In Business I can have my problem solver (or solvers) based on the Domain bounds.
* In Infrastructure I will have my File System access to load the files, but can be easily replaced by other Infrastructure that reads from a database or an external web service (I'm bound to no one :laughing:)
* My host will make use of all the components to render the application usable, but only conserning itself with the inputs

<p align="right">(<a href="#top">back to top</a>)</p>



### Built With

* [.NET 6](https://dotnet.microsoft.com/en-us/)
* C#
* [Fluent Assertions (nuget package)](https://www.nuget.org/packages/FluentAssertions/6.6.0/)
* [Moq (nuget package)](https://github.com/moq/moq4)
* [QuilGraph (nuget package)](https://github.com/KeRNeLith/QuikGraph)
* [System.IO.Abstraction (nuget package)](https://github.com/TestableIO/System.IO.Abstractions)
* [xUnit (nuget package)](https://github.com/xunit/xunitm)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This application is prepared to support multiple solvers for the Word Ladder problem, but for now it have only one available (so no choice on the application start).\
The input data can be passed by arguments or inside the application itself (if missing or invalid).\
The arguments can be passed like this:
* -S:'value' -> The start word
* -E:'value' -> The end word
* -D:'value' -> The dictionary file path"
* -O:'value' -> The output folder
* -H -> The help menu

WordLadderHost.exe -S:start -E:end -D:somePath\words-english.txt -O:someOtherPath

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
## Word Ladder Solvers

As stated before the solution is prepared to support multiple solvers for the Word Ladder Solver. Even if for now only one is implemented new ones can be added with low effort if they follow the same contract (defined by the Business):

```
public interface IWordLadderSolver
    {
        /// <summary>
        /// Solve Word Ladder for the given parameters
        /// </summary>
        /// <param name="startWord">The start word</param>
        /// <param name="endWord">The end word</param>
        /// <param name="dictionary">The dictionary to use</param>
        /// <returns>The shortest Word Path between start and end words in the given dictionary</returns>
        /// <exception cref=""></exception>
        public WordPath SolveWordLadder(Word startWord, Word endWord, WordLadderDictionary dictionary);
    }
```

From here each solver is free to implement what they need.

### Graph Solver

This solver was made based on the ideia of constructing a graph from the dictionary provided by the user and then search for the shortest path between start and end words. (If the words are not present in the dictionary or a path is impossible to find, it will return an empty WordPath).

To avoid performance issues the graph builded by this solver will not contain the full map for the provided dictionary. Instead it will be builded "per level".\
In each level it will search the dictionary for all words with 1 different letter (taking in count there position on the word) from a pre-selected word until it receive the end word (the goal) from the dictionary).\
To be easier to understand, lets see bellow an example:

Inputs:\
Dictionary: ["bears", "parts", "teats", "tarts", "boats", "start", "ports", "stars", "beats", "coats", "seats", "posts", "sears", "costs", "terts"]\
Start Word: "start"\
End Word: "tarts"

Level 1\
Word to process => start\
Graph Nodes => [start]\
Words from Dictionary with 1 change of letter => ["stars"]\
Words already processed => [start]

Level 2\
Word to process => stars\
Graph Nodes => [start, stars]\
Words from Dictionary with 1 change of letter => ["sears"]\
Words already processed => [start, stars]

Level 3\
Word to process => sears\
Graph Nodes => [start, stars, sears]\
Words from Dictionary with 1 change of letter => ["bears", "seats"]\
Words already processed => [start, stars, sears]

Level 4\
Word to process => bears\
Graph Nodes => [start, stars, sears, bears]\
Words from Dictionary with 1 change of letter => ["beats"]\
Words already processed => [start, stars, sears, bears]

Word to process => seats\
Graph Nodes => [start, stars, sears, bears, seats]\
Words from Dictionary with 1 change of letter => ["beats", "teats"]\
Words already processed => [start, stars, sears, bears, seats]

Level 5\
Word to process => beats\
Graph Nodes => [start, stars, sears, bears, seats, beats]\
Words from Dictionary with 1 change of letter => ["teats", "boats"]\
Words already processed => [start, stars, sears, bears, seats, beats]

Word to process => teats\
Graph Nodes => [start, stars, sears, bears, seats, beats, teats]\
Words from Dictionary with 1 change of letter => ["terts"]\
Words already processed => [start, stars, sears, bears, seats, beats, teats]

Level 6\
Word to process => boats\
Graph Nodes => [start, stars, sears, bears, seats, beats, teats, boats]\
Words from Dictionary with 1 change of letter => ["coats"]\
Words already processed => [start, stars, sears, bears, seats, beats, teats, boats]

Word to process => terts\
Graph Nodes => [start, stars, sears, bears, seats, beats, teats, boats, terts]\
Words from Dictionary with 1 change of letter => ["tarts"]\
Words already processed => [start, stars, sears, bears, seats, beats, teats, boats, terts]
- Process Stops, end word found

Returned Path:
start -> stars -> sears -> seats -> teats -> terts -> tarts



<!-- CONTACT -->
## Contact

Luis Carreira - [@linkedin_handle](https://www.linkedin.com/in/lu%C3%ADs-carreira-47a14811/) - luiscarlosfc@outlook.com

<p align="right">(<a href="#top">back to top</a>)</p>
