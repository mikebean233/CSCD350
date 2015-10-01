import java.util.Random;

public class MineField
{
	public static Random ran;
	public char[][] _field;
	public int _rows, _cols;
	
	public MineField(int rows, int cols, int mineProb)
	{
		if(ran == null)
			ran = new Random();
		
		if(rows == 0 || cols == 0)
			return;
		
		_rows = rows;
		_cols = cols;
		_field = new char[rows][cols];
		for(int rowIndex = 0; rowIndex < rows; ++ rowIndex)
		{
			for(int colIndex = 0; colIndex < cols; ++ colIndex)
			{
				int ranValue = ran.nextInt(99) + 1;
				if(ranValue <= mineProb)
					_field[rowIndex][colIndex] = '*';
				else
					_field[rowIndex][colIndex] = '.';
			}
		}
		
	}

	@Override
	public String toString()
	{
		if(_rows != 0 && _cols != 0)
		{
			String output = "";

			output += _rows + " " + _cols + " " + System.lineSeparator();
			
			for(int rowIndex = 0; rowIndex < _rows; ++rowIndex)
			{
				for(int colIndex = 0; colIndex < _cols; ++colIndex)
				{
			        output += _field[rowIndex][colIndex];
				}
				output += System.lineSeparator();
			}
			
			return output;
		}
		else
			return "";
	}
}
