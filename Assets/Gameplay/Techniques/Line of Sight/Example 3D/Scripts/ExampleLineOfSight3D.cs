using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class ExampleLineOfSight3D : MonoBehaviour
{
    [field: SerializeField] public Vector2Int PlayerPosition    { get; private set; }
    [field: SerializeField] public Vector2Int DestinationTest   { get; private set; }
    [field: SerializeField] public Transform GridContainer      { get; private set; }
    [field: SerializeField] public Spell Spell                  { get; private set; }
    [field: SerializeField] public CellVisibility CellVisibilityPrefab { get; private set; }

    Dictionary<Vector2, CellView3D> Grid; // In this case the dimensions of the grid is not a perfect square or rectangle. Better use a Dictionary now
    HashSet<CellVisibility> _visibleCellsView;

    void Start()
    {
        Grid = new Dictionary<Vector2, CellView3D>();
        CellView3D[] cells = GridContainer.GetComponentsInChildren<CellView3D>();

        foreach (CellView3D cell in cells)
        {
            Grid.Add(cell.GridPosition, cell);
        }

        _visibleCellsView = new HashSet<CellVisibility>();


        RenderSpellRange(PlayerPosition, Spell);
    }

    private void RenderSpellRange(Vector2Int origin, Spell spell)
    {
        for (int x = origin.x - spell.Range; x <= origin.x + spell.Range; x++)
        {
            for (int y = origin.y - spell.Range; y <= origin.y + spell.Range; y++)
            {
                if (x < 0 || y < 0) continue;
                if (!Grid.ContainsKey(new Vector2(x,y))) continue;
                if(Grid[new Vector2(x,y)].IsObstacle) continue;
                // if (x >= Grid.GetLength(0) || y >= Grid.GetLength(1)) continue;
                // if (Grid[x, y].IsObstacle) continue;
                if (x == origin.x && y == origin.y) continue;
                int distance = Mathf.Abs((x - origin.x)) + Mathf.Abs((y - origin.y));
                if (distance > spell.Range) continue;

                List<Vector2Int> result = LineDraw(origin, new Vector2Int(x, y));
                bool hasSight = HasSight(origin, new Vector2Int(x,y));
                if(hasSight)
                {
                    CellVisibility cellVisibilityView = Instantiate(CellVisibilityPrefab);
                    CellView3D cell3D = Grid[new Vector2(x, y)];
                    cellVisibilityView.SetVisible(true);
                    cellVisibilityView.transform.position = new Vector3(cell3D.transform.position.x, 0.5f, cell3D.transform.position.z);
                }
                else
                {
                    CellVisibility cellVisibilityView = Instantiate(CellVisibilityPrefab);
                    CellView3D cell3D = Grid[new Vector2(x, y)];
                    cellVisibilityView.SetVisible(false);
                    cellVisibilityView.transform.position = new Vector3(cell3D.transform.position.x, 0.5f, cell3D.transform.position.z);
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

    [ContextMenu("TextDrawLine")]
    public async void TestPath()
    {
        // foreach (Vector2 cell in Grid.Keys)
        // {
        //     cell.Clear();
        // }

        List<Vector2Int> result = LineDraw(PlayerPosition, DestinationTest);
        foreach (Vector2Int cell in result)
        {
            CellVisibility cellVisibilityView = Instantiate(CellVisibilityPrefab);
            CellView3D cell3D = Grid[new Vector2(cell.x, cell.y)];
            cellVisibilityView.transform.position = new Vector3(cell3D.transform.position.x, 0.5f, cell3D.transform.position.z);
            _visibleCellsView.Add(cellVisibilityView);
            // Grid[cell.x, cell.y].SetVisible(true);
            await Task.Delay(TimeSpan.FromSeconds(0.1f));
        }
    }

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
            if(Grid[new Vector2(cell.x, cell.y)].IsObstacle)
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

}
