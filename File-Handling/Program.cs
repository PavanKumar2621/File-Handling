using File_Handling;

Console.WriteLine("Hello, World!");
var filewrite = new FileHandler();

while (true)
{
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("Welcome to File Handling Concept");
    Console.WriteLine("Select which option You want\n1. Write Date to File.\n2. Read Data From File." +
        "\n3. Write Date to a File to Save in Binary Format.\n4. Retrive Data From File Which is in Binary Format." +
        "\n5. Copy an image."+
        "\n6. Exit Program");    

    int option = Convert.ToInt16(Console.ReadLine());
    switch (option)
    {
        case 1: call1(); break;
        case 2: call2(); break;
        case 3: call3(); break;
        case 4: call4(); break;
        case 5: call5(); break;
        case 6: Console.WriteLine("Program Exiting..."); return;
        default: Console.WriteLine("Wrong Selection."); break;
    }
}

void call1()
{
    Console.WriteLine("Enter a Line to be append to a File");
    string? line = Console.ReadLine();
    FileStream fsw = new FileStream("WriteFile.txt", FileMode.Append, FileAccess.Write);
    if (line != null)
        filewrite.StoreDataInFile(fsw, line);
    Console.WriteLine("Data Written in File Successfully.");
}
void call2()
{
    FileStream fsr = new FileStream("WriteFile.txt", FileMode.Open, FileAccess.Read);
    string? line = filewrite.RetriveDataInFile(fsr);
    Console.WriteLine($"Retrived File Data\n {line}");
}

void call3() 
{       
    Console.WriteLine("Enter a String to be append to a File");
    string? s = Console.ReadLine();
    Console.WriteLine("Enter an Integer value to be append to a File");
    int val = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter a Float value to be append to a File");
    float fval = Convert.ToSingle(Console.ReadLine());

    FileStream fsr = new FileStream("Binary.txt", FileMode.Create, FileAccess.Write);
    if (s != null)
        filewrite.StoreBinaryDataInFile(fsr, s, val, fval);    
    Console.WriteLine("Data Written in File Successfully.");
}
void call4()
{
    FileStream fsr = new FileStream("Binary.txt", FileMode.Open, FileAccess.Read);
    string s = filewrite.RetirveBinaryDataInFile(fsr);
    Console.WriteLine(s);
}
void call5()
{
    string s = @"C:\Users\HP\OneDrive\Pictures\Screenshots\Image.png";
    FileStream fsr = new FileStream(s, FileMode.Open, FileAccess.Read);
    FileStream fsw = new FileStream("ImageCopy.png", FileMode.Create, FileAccess.Write);
    //int buffer;
    //while((buffer = fsr.ReadByte()) != -1)
    //{
    //    fsw.WriteByte((byte)buffer);
    //}
    //fsw.Flush();
    byte[] buffer = new byte[fsr.Length];
    fsr.Read(buffer, 0, buffer.Length);
    fsw.Write(buffer, 0, buffer.Length);
    Console.WriteLine("Image Copied Successfully.");
}