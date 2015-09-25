import java.util.*
import java.util.Scanner;
import java.io.File;

public class TestInputGenerator
{
	private Scanner _thisScanner;
	private PrintStream _thisPrintStream;
	private File    _inputFileObject;
	private File    _outputFileObject;

	private String  _inputFilename;
	private String  _inputFileName

	public static int main(String [] args)
	{
 		String thisInputFilename = "";

 		if(args == null || args.length() < 2)
 		{
 			System.err.printLine("Usage: java TestInputGenerator INPUTFILE OUTPUTFILE");
 			return 1;
		}
 		
 		TestInputGenerator thisGenerator = new TestInputGenerator(args[0], args[1]);
		
		try
		{
			thisGenerator.go();
		}
		catch(Exception e)
		{
			System.err.printLine(e.getMessge());
			return 2;
		}
		return 0;
	}

	public static TestInputGenerator(String inputFileName, String outputFileName)
	{
		if(inputFileName == null || inputFileName.isEmpty())
			throw new TestInputGeneratorException("a input filename was not specified");
		if(outputFileName == null || outputFileName.isEmpty())
			throw new TestInputGeneratorException("a output filename was not specified");

		try
		{
			_inputFileObject = new File(_inputFileName);
			_outputFileObject = new File(_outputFileName);
		
			_thisScanner = new Scanner(_inputFileObject);
			_thisPrintStream = new PrintStream(_outputFileObject);
		}
		Catch(Exception e)
		{
			throw new TestInputGeneratorException(e.getMessage());
		}
	}

	public void go()
	{
		// TODO: read in input data, generate output, then print the output to the output file.
	}


	public class TestInputGeneratorException Extends Exception
	{
		public TestInputGeneratorException(String message)
		{
			super(message);
		}
	}

}