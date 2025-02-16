import java.util.*;

public class MazeSolver {

    static class Point {
        int x, y;

        Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    static int[] dx = {0, 0, 1, -1};
    static int[] dy = {1, -1, 0, 0};

    public static boolean isValid(int x, int y, char[][] maze, boolean[][] visited) {
        return x >= 0 && x < maze.length && y >= 0 && y < maze[0].length && maze[x][y] != '#' && !visited[x][y];
    }

    public static int bfs(char[][] maze, Point start, Point end) {
        int rows = maze.length;
        int cols = maze[0].length;
        boolean[][] visited = new boolean[rows][cols];
        Queue<Point> queue = new LinkedList<>();
        queue.add(start);
        visited[start.x][start.y] = true;
        int steps = 0;

        while (!queue.isEmpty()) {
            int size = queue.size();
            for (int i = 0; i < size; i++) {
                Point current = queue.poll();
                if (current.x == end.x && current.y == end.y) {
                    return steps;
                }
                for (int j = 0; j < 4; j++) {
                    int newX = current.x + dx[j];
                    int newY = current.y + dy[j];
                    if (isValid(newX, newY, maze, visited)) {
                        visited[newX][newY] = true;
                        queue.add(new Point(newX, newY));
                    }
                }
            }
            steps++;
        }
        return -1; // If no path is found
    }

    public static void main(String[] args) {
        char[][] maze = {
                {'S', '.', '.', '#', '.', '.', '.'},
                {'.', '#', '.', '.', '#', '.', '.'},
                {'.', '#', '.', '.', '.', '#', '.'},
                {'.', '.', '#', '#', '.', '.', '.'},
                {'#', '.', '#', 'E', '.', '#', '.'}
        };

        Point start = new Point(0, 0);
        Point end = new Point(4, 3);

        int result = bfs(maze, start, end);

        if (result != -1) {
            System.out.println("Shortest Path Length: " + result);
        } else {
            System.out.println("No Path Found");
        }
    }
}
