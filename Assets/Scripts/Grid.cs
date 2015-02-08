using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public static int w = 10;
	public static int h = 24; // extra 4 units for buffer
	public static int gridH = 19;
	public static Transform[,] grid = new Transform[w,h];
	// Use this for initialization
	public static ParticleSystem destroyParticles;
	public static int score = 0;
	public static Vector2 RoundVec2(Vector2 v){
		return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
	}

	public static bool IfInsideBorder(Vector2 pos) {
		return ((int)pos.x >= 0 &&
		        (int)pos.x < w &&
		        (int)pos.y >= 0);
	}

	public static void DeleteRow(int r) {
		for (int x = 0; x < w; ++x) {
			Instantiate(destroyParticles, new Vector3(x, r, -0.5f),Quaternion.identity);
			Destroy(grid[x, r].gameObject); // gameObject is the inherited memember -- the game object this component is attached to
			grid[x, r] = null;
		}
		score ++;
	}

	public static void DecreaseRow(int r) {
		for (int x = 0; x < w; ++x) {
			if (grid[x, r] != null) {
				// Move one towards bottom
				grid[x, r-1] = grid[x, r];
				grid[x, r] = null;
				
				// Update Block position
				grid[x, r-1].position += new Vector3(0, -1, 0);
			}
		}
	}

	public static void DecreaseRowsAbove(int r) {
		for (int i = r; i < h; ++i)
			DecreaseRow(i);
	}

	public static bool IsRowFull(int y) {
		for (int x = 0; x < w; ++x)
			if (grid[x, y] == null)
				return false;
		return true;
	}

	public static void DeleteFullRows() {
		for (int y = 0; y < h; ++y) {
			if (IsRowFull(y)) {
				DeleteRow(y);
				DecreaseRowsAbove(y+1);
				--y;
			}
		}
	}
	public static int Height(){
		for(int i = (gridH-1); i >= 0; --i){
			for(int j = 0; j < w; ++j){
				if (grid[j,i] != null) {
					return i;
				}
			}
		}
		return 0;
	}
}
