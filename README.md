Maze as Grid:

S is the start, E is the end, # is a wall, and . is an open path.
BFS (Breadth-First Search) Approach:

BFS is used because it finds the shortest path in an unweighted grid.
Queue stores the cells to visit next.
Visited array prevents revisiting cells.
How It Works:

Start from S and explore all 4 directions (up, down, left, right).
Each step represents moving to neighboring cells.
If we reach E, we return the steps taken.
If no path is found, return -1.
Key Idea:

BFS moves level by level (like water filling out), so the first time we reach E is the shortest path.
