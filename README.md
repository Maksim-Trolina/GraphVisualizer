#  GraphVisualizer

GraphVisualizer is an application for simpler and more visual presentation of graphs using
visual effects. This application is designed to assist the user in learning about graphs and 
related algorithms.

## System requirements and how to get started:

To use this application, you need .NET Core + .Net FrameWork.
Path to exe file: GraphVisualizer\Forms\bin\Release\netcoreapp3.1

## How to use the app:

After starting the application, it appears with the option to create a new graph or load an existing one.
The graph loading function is still under development. 
After clicking on the "Matrix" button, a window opens, in which you can enter the number of vertices 
in the graph, then click "OK" and an adjacency matrix for these vertices will be generated in the same 
window.

### Adjacency matrix

The weights of the edges can be entered into this matrix according to the following rule: the initial 
vertices are indicated vertically, and the final vertices are indicated horizontally.
Then the user needs to click "Create vertexes" to visualize this graph.

It is also possible to go straight to drawing. To do this, without creating an adjacency matrix, press
"Create vertexes".

### Drawing Graph

In the drawing menu, the user can click on the left mouse button to draw vertices (they should not 
intersect with those already drawn).

In order to move a vertex, first click on it with the left mouse button (it will be highlighted in black), 
and then in the free zone where you would like to move it.

+ To draw an edge, you need to select the initial vertex with the left mouse button, and then the final one.

+ To reset the selection of a vertex, left-click on it again.

+ To view the adjacency matrix, click "Weight table". To hide it, click again. Adjacency matrix expands when 
drawing new vertices.

+ To view the adjacency list, click "Adjacency list". It displays connections between vertices in real time.

+ To check the graph for a cycle, click "Show cycle". The edges of the loop will be highlighted in green. 
Press again to remove the backlight.

### Saving graph

In order to save the drawn graph, press "Save graph", then select the folder to save and enter the file name. 
The save format is json.

## Technologies used:

C#,Windows Forms, .NET FrameWork + .Net Core, NUnit, Visual Studio 2019

## Development team:

Team Leader - Maxim Panasenko
Developers - Danil Karimov, 
Evgeny Kulik


