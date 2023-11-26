using UnityEngine;
using System.Collections;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class MazeSpawner : MonoBehaviour
{
	// public enum MazeGenerationAlgorithm{
	// 	PureRecursive,
	// 	RecursiveTree,
	// 	RandomTree,
	// 	OldestTree,
	// 	RecursiveDivision,
	// }

	// public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
	public GameObject Floor = null;
	public GameObject Wall = null;
	public GameObject Pillar = null;
	private int Rows = TheMazeSettings.rows;
	private int Columns = TheMazeSettings.rows;
	public float CellWidth = 5;
	public float CellHeight = 5;
	public bool AddGaps = true;
	public GameObject GoalPrefab = null;
	public int speed = 1;

	private MazeGenerator mMazeGenerator = null;

	void Start()
	{

		Debug.Log("Rows: " + Rows + " Columns: " + Columns);
		mMazeGenerator = new MazeGenerator(Rows, Columns);
		mMazeGenerator.GenerateMaze();
		for (int row = 0; row < Rows; row++)
		{
			for (int column = 0; column < Columns; column++)
			{
				float x = column * (CellWidth + (AddGaps ? .2f : 0));
				float z = row * (CellHeight + (AddGaps ? .2f : 0));
				MazeCell cell = mMazeGenerator.GetMazeCell(row, column);
				GameObject flr;

				flr = Instantiate(Floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
				flr.transform.parent = transform;

				if (cell.WallRight)
				{
					flr = Instantiate(Wall, new Vector3(x + CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;// right
					flr.transform.parent = transform;
				}
				if (cell.WallFront)
				{
					flr = Instantiate(Wall, new Vector3(x, 0, z + CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;// front
					flr.transform.parent = transform;
				}
				if (cell.WallLeft)
				{
					flr = Instantiate(Wall, new Vector3(x - CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject;// left
					flr.transform.parent = transform;
				}
				if (cell.WallBack)
				{
					flr = Instantiate(Wall, new Vector3(x, 0, z - CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;// back
					flr.transform.parent = transform;
				}
				// if(cell.IsGoal && GoalPrefab != null){
				// 	flr = Instantiate(GoalPrefab,new Vector3(x,1,z), Quaternion.Euler(0,0,0)) as GameObject;
				// 	flr.transform.parent = transform;
				// }
				if (column == Columns - 1 && row == Rows - 1)
				{
					flr = Instantiate(GoalPrefab, new Vector3(Columns * (CellWidth + (AddGaps ? .2f : 0)) - CellWidth, .1f, Rows * (CellWidth + (AddGaps ? .2f : 0))), Quaternion.Euler(0, 0, 0)) as GameObject;

					flr = Instantiate(Floor, new Vector3(Columns * (CellWidth + (AddGaps ? .2f : 0)) - CellWidth, 0, Rows * (CellWidth + (AddGaps ? .2f : 0))), Quaternion.Euler(0, 0, 0)) as GameObject;
					flr.transform.parent = transform;
					x = (Columns - 1) * (CellWidth + (AddGaps ? .2f : 0));
					z = Rows * (CellHeight + (AddGaps ? .2f : 0));
					flr = Instantiate(Wall, new Vector3(x, 0, z + CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
					flr = Instantiate(Wall, new Vector3(x - CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject;// left
					flr = Instantiate(Wall, new Vector3(x + CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;// right


					flr.transform.parent = transform;

				}
			}
		}

		// tmp = Instantiate(Floor,new Vector3(x,0,z), Quaternion.Euler(0,0,0)) as GameObject;
		// tmp.transform.parent = transform;


		if (Pillar != null)
		{
			for (int row = 0; row < Rows + 1; row++)
			{
				for (int column = 0; column < Columns + 1; column++)
				{
					float x = column * (CellWidth + (AddGaps ? .2f : 0));
					float z = row * (CellHeight + (AddGaps ? .2f : 0));
					GameObject tmp = Instantiate(Pillar, new Vector3(x - CellWidth / 2, 0, z - CellHeight / 2), Quaternion.identity) as GameObject;
					tmp.transform.parent = transform;
					if (row == Rows && column == Columns)
					{
						tmp = Instantiate(Pillar, new Vector3(Columns * (CellWidth + (AddGaps ? .2f : 0)) - CellWidth + CellWidth / 2, 0, Rows * (CellWidth + (AddGaps ? .2f : 0)) + CellHeight / 2), Quaternion.identity) as GameObject;
						tmp.transform.parent = transform;
					}
				}
			}
		}
	}
}
