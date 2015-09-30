import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;
import java.util.ArrayList;
import java.io.File;
import java.io.PrintStream;
import java.lang.System;

public class TestInputGenerator
{
	private Scanner _thisScanner;
	private PrintStream _thisPrintStream;
	private File    _inputFileObject;
	private File    _outputFileObject;

	private String  _inputFileName;
	private String  _outputFileName;

	public static void main(String [] args) throws Exception
	{
 		if(args == null || args.length < 2)
 		{
 			String output = "Usage: java TestInputGenerator INPUTFILE OUTPUTFILE" + System.lineSeparator();
 			output += "input file format:" + System.lineSeparator();
 			output += "NoRows NoCols MineProbability" + System.lineSeparator();
 			output += "NoRows NoCols MineProbability" + System.lineSeparator();
 			
 			System.err.println(output);
 			System.exit(1);
		}
 		
 		TestInputGenerator thisGenerator = new TestInputGenerator(args[0], args[1]);
		
		try
		{
			thisGenerator.go();
		}
		catch(Exception e)
		{
			System.err.println(e.getMessage());
			System.exit(2);
		}
		System.exit(0);
	}

	public TestInputGenerator(String inputFileName, String outputFileName) throws Exception
	{
		if(inputFileName == null || inputFileName.isEmpty())
			throw new TestInputGeneratorException("a input filename was not specified");
		if(outputFileName == null || outputFileName.isEmpty())
			throw new TestInputGeneratorException("a output filename was not specified");

		try
		{
			_inputFileName = inputFileName;
			_outputFileName = outputFileName;
			
			_inputFileObject = new File(_inputFileName);
			_outputFileObject = new File(_outputFileName);
		
			if(!_outputFileObject.exists())
				_outputFileObject.createNewFile();
			_thisScanner = new Scanner(_inputFileObject);
			_thisPrintStream = new PrintStream(_outputFileObject);
		}
		catch(Exception e)
		{
			throw new TestInputGeneratorException(e.getMessage());
		}
	}

	public void go()
	{
		ArrayList<MineField> mineFields = new ArrayList<MineField>();
		
		while(_thisScanner.hasNextByte())
		{
			String thisLine = _thisScanner.nextLine();
			String[] tokens = thisLine.split(" ");
			
			int rowCount = Integer.parseInt(tokens[0]);
			int colCount = Integer.parseInt(tokens[1]);
			int mineProb = Integer.parseInt(tokens[2]);
			
			mineFields.add(new MineField(rowCount, colCount, mineProb));
		}
		
		String output = "";
		for(MineField thisMineField: mineFields)
		{
			output += thisMineField.toString(); 
		}
		
		output += "0 0" + System.lineSeparator();
		_thisPrintStream.print(output);
	}

	public class TestInputGeneratorException extends Exception
	{
		private static final long serialVersionUID = 1L;

		public TestInputGeneratorException(String message)
		{
			super(message);
		}
	}
}