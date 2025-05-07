using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LineOfSightSceneController : MonoBehaviour
{
    [field: SerializeField] public Vector2Int PlayerPosition { get; private set; }
    [field: SerializeField] public Vector2Int DestinationTest { get; set; }
    [field: SerializeField] public Transform GridContainer { get; private set; }
    [field: SerializeField] public Spell Spell { get; private set; }

    CellView[,] Grid;

    void Start()
    {
        RenderGrid();
        RenderSpellRange(PlayerPosition, Spell);
    }

    [ContextMenu("TextDrawLine")]
    public async void TestPath()
    {
        foreach (CellView cell in Grid)
        {
            cell.Clear();
        }

        List<Vector2Int> result = LineDraw(PlayerPosition, DestinationTest);
        foreach (Vector2Int cell in result)
        {
            Grid[cell.x, cell.y].SetVisible(true);
            await Task.Delay(TimeSpan.FromSeconds(0.1f));
        }
    }

    private void RenderGrid()
    {
        Grid = new CellView[11, 11];
        CellView[] cells = GridContainer.GetComponentsInChildren<CellView>();

        foreach (CellView cell in cells)
        {
            Grid[cell.X, cell.Y] = cell;
        }

        Grid[PlayerPosition.x, PlayerPosition.y].SetPlayer();
    }

    private void RenderSpellRange(Vector2Int origin, Spell spell)
    {
        for (int x = origin.x - spell.Range; x <= origin.x + spell.Range; x++)
        {
            for (int y = origin.y - spell.Range; y <= origin.y + spell.Range; y++)
            {
                if (x < 0 || y < 0) continue;
                if (x >= Grid.GetLength(0) || y >= Grid.GetLength(1)) continue;
                if (Grid[x, y].IsObstacle) continue;
                if (x == origin.x && y == origin.y) continue;
                int distance = Mathf.Abs((x - origin.x)) + Mathf.Abs((y - origin.y));
                if (distance > spell.Range) continue;

                List<Vector2Int> result = LineDraw(origin, new Vector2Int(x, y));
                bool hasSight = HasSight(origin, new Vector2Int(x,y));
                if(hasSight)
                {
                    Grid[x, y].SetVisible(true);
                }
                else
                {
                    Grid[x, y].SetVisible(false);
                }
            }
        }
    }

    private bool HasSight(Vector2Int origin, Vector2Int destination)
    {
        List<Vector2Int> line = LineDraw(origin, destination);
        if(line[line.Count-1] == destination)
            return true;
        return false;
    }

    // After suffering and avoiding to simply copy Bresenham Algorithm
    // I've still persisted in the line function
    // But Now I've realized that the slope (deltaY/deltaX)
    // can be fractioned, and it tells me how much I need to move in X and Y for each microstep. 
    // And now, instead of iterating over the indexes
    // I now start from origin and move forward the slop in small pieces
    // and add to the cellsPainted all the non repeating cells that I've
    // found over the iteration.
    // It is not performatic but I am proud of it. 
    private List<Vector2Int> LineDraw(Vector2Int origin, Vector2Int destination)
    {
        List<Vector2Int> resultingLine = new List<Vector2Int>();

        int precision       = 3;
        int deltaX          = destination.x - origin.x;
        int deltaY          = destination.y - origin.y;
        int amountOfSteps   = precision * Math.Max(Mathf.Abs(deltaX), Mathf.Abs(deltaY));
        int currentStep     = 0;
        float m             = ((float)deltaY/deltaX);
        // float b             = origin.y - m * origin.x;

        float dx            = (float)deltaX / amountOfSteps;
        float dy            = (float)deltaY / amountOfSteps;
        float x             = origin.x;
        float y             = origin.y;

        HashSet<Vector2Int> cellsPainted = new HashSet<Vector2Int>();
        while(currentStep < amountOfSteps)
        {
            Vector2Int cell = new Vector2Int(Convert.ToInt32(x), Convert.ToInt32(y));
            if(Grid[cell.x, cell.y].IsObstacle)
                return resultingLine;
            if (!cellsPainted.Contains(cell))
            {
                cellsPainted.Add(cell);
                resultingLine.Add(cell);
            }
            x += dx;
            y += dy;
            currentStep++;
        }
        return resultingLine;
    }

    // Line Draw using linear function formula
    // I know the performance is terrible but
    // this is how I feel comfortable to understand and solve
    // this problem.
    private List<Vector2Int> LineDraw0(Vector2Int origin, Vector2Int destination)
    {
        List<Vector2Int> resultingLine = new List<Vector2Int>();

        // Linear Function : y = mx + b 
        int deltaX = destination.x - origin.x;
        int deltaY = destination.y - origin.y;
        float m = (float)deltaY / deltaX;              // This is the Slope, it literally means how much Y grows faster than X.
        // For example: If m = 3 it is just telling us that for each time X increases 1 unit, the Y will increase 3 unit
        float b = origin.y - m * origin.x;      // b represents the offset from the origin

        // With m and b known. If you give me any X, I can tell you what Y will be
        // and with any Y value you provide, I can tell you what is the X

        // Straight Lines (Up and Down)
        if (origin.x == destination.x)
        {
            if (origin.y < destination.y)
            {
                for (int y = origin.y; y <= origin.y + deltaY; y++)
                {
                    if (y == origin.y) continue;
                    if (Grid[origin.x, y].IsObstacle)
                        break;
                    resultingLine.Add(new Vector2Int(origin.x, y));
                }
            }
            else
            {
                for (int y = origin.y; y >= origin.y + deltaY; y--)
                {
                    if (y == origin.y) continue;
                    if (Grid[origin.x, y].IsObstacle)
                        break;
                    resultingLine.Add(new Vector2Int(origin.x, y));
                }
            }
            return resultingLine;
        }

        // My idea here is to find the biggest axis to iterate
        // I want to iterate over the bigger axis
        // and the other axis I predict the exact value with the linear function
        // Then, with this exact value I approximate it to the int to get the cell index
        //
        // for example if the X axis is 8 units and Y axis is 4
        // I want to loop the 8 units from X and use the linear function
        // to find the exact Y at this point X and with this exact Y (that is a float number)
        // I can paint in my grid the closest cell to this X and Y
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX > 0)
            {
                for (int x = origin.x; x <= origin.x + deltaX; x++)
                {
                    int y = Convert.ToInt32(Math.Round(m * x + b));
                    if (x == origin.x && y == origin.y) continue;
                    if (Grid[x, y].IsObstacle)
                        break;
                    resultingLine.Add(new Vector2Int(x, y));
                }
            }
            else
            {
                for (int x = origin.x; x >= origin.x + deltaX; x--)
                {
                    int y = Convert.ToInt32(Math.Round(m * x + b));
                    if (x == origin.x && y == origin.y) continue;
                    if (Grid[x, y].IsObstacle)
                        break;
                    resultingLine.Add(new Vector2Int(x, y));
                }
            }
        }
        else
        {
            if (deltaY > 0)
            {
                for (int y = origin.y; y <= origin.y + deltaY; y++)
                {
                    int x = Convert.ToInt32(Math.Round((y - b) / m));
                    if (x == origin.x && y == origin.y) continue;
                    if (Grid[x, y].IsObstacle)
                        break;
                    resultingLine.Add(new Vector2Int(x, y));
                }
            }
            else
            {
                for (int y = origin.y; y >= origin.y + deltaY; y--)
                {
                    int x = Convert.ToInt32(Math.Round((y - b) / m));
                    if (x == origin.x && y == origin.y) continue;
                    if (Grid[x, y].IsObstacle)
                        break;
                    resultingLine.Add(new Vector2Int(x, y));
                }
            }
        }

        return resultingLine;
    }
}
