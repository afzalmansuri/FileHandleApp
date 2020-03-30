using System;
using System.IO;

namespace FileHandleApp
{
    class Program
    {

        public void Menu()
        {

            Console.WriteLine("------------------Welcome To File Handling App------------------------");
             
            Console.WriteLine(" 1.Create a file");
            Console.WriteLine(" 2.Rename file ");
            Console.WriteLine(" 3.Concat two files");
            Console.WriteLine(" 4.Display Content Of file");
            Console.WriteLine(" 5.Write in a file");
            Console.WriteLine(" 6.Delete File");
            Console.WriteLine(" 7.Copy File ");
            Console.WriteLine("8. Exit");
            Console.Write(" Enter Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreateFile();
                    break;
                case 2:
                   RenameFile();
                    break;
                case 3:
                   ConcatFile();
                    break;
                case 4:
                   DisplayContent();
                    break;
                case 5:
                   WriteFile();
                    break;
                case 6:
                   DeleteFile();
                    break;
                case 7:
                   CopyFile();
                    break;
                case 8:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter Valid Choice");
                    break;
            }

        }

       /* For Create a File*/

        public void CreateFile()
        {

            string filepath = @"C:\Users\DELL\Desktop\radixfile\";
            Console.Write("Enter FileName (use .txt extension) : ");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (!File.Exists(Path))
            {
                var file = File.CreateText(Path);
                Console.WriteLine("file successfully Created");
                file.Close();
                Menu();
            }
            else
            {
                Console.WriteLine("Already Exits");
                Menu();

            }

        }

        /*for create a file end*/



            /*For rename file function start*/

        public void RenameFile()
        {
            string filepath = @"C:\Users\DELL\Desktop\radixfile\";
            Console.Write("Enter FileName (use .txt extension) : ");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;

            FileInfo fileInfo = new System.IO.FileInfo(Path);

            if (fileInfo.Exists)
            {
                Console.Write("Enter FileName (use .txt extension) : ");
                string newName = Console.ReadLine();
                string newPath = filepath + newName;
                fileInfo.MoveTo(newPath);
                Console.WriteLine("File Rename Successfully");
                Menu();
            }
            else
            {
                Console.WriteLine("File Not exist");
                Menu();
            }
        }


        /*for rename file function end*/


            /*for concate a file start*/
        public void ConcatFile()
        {
            string filepath = @"C:\Users\DELL\Desktop\radixfile\";
            Console.Write("Enter First FileName (use .txt extension) : ");
            string firstfile = Console.ReadLine();
            string FirstFilePath = filepath + firstfile;
            Console.Write("Enter Second FileName (use .txt extension) : ");
            string secondfile = Console.ReadLine();
            string secondFilePath = filepath + secondfile;
            if (File.Exists(FirstFilePath))
            {
                FileStream f1 = null;
                FileStream f2 = null;
                f1 = File.Open(FirstFilePath, FileMode.Append);
                f2 = File.Open(secondFilePath, FileMode.Open);
               
                StreamReader sr = new StreamReader(f2);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    StreamWriter sw = new StreamWriter(f1);
                    sw.Write(line);
                    sw.Close();
                    
                }
                sr.Close();
                Console.WriteLine("Successfully Done");
                Menu();
            }
            else
            {
                Console.WriteLine("File Not Found");
                Menu();
            }

        }

        /*for concate a file function end*/

           /* for copy a file function start*/
        public void CopyFile()
        {
            string filepath = @"C:\Users\DELL\Desktop\radixfile\";
            Console.Write("Enter FileName (use .txt extension) : ");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (File.Exists(Path))
            {
                Console.Write("Enter FileName where you want to copy (use .txt extension) : ");
                string filecopy = Console.ReadLine();
                string newPath = filepath + filecopy;
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);

                }
                File.Copy(Path, newPath);

                Console.WriteLine("Successfully copied...");
                Menu();
            }
        }

        /*for copy a file function end*/

           /* for display content of file function start*/
        public void DisplayContent()
        {
            string filepath = @"C:\Users\DELL\Desktop\radixfile\";
            Console.Write("Enter FileName (use .txt extension) : ");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (File.Exists(Path))
            {
                StreamReader sr = new StreamReader(Path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine(line);
                    Console.WriteLine("---------------------------------------");
                }
                sr.Close();
               
            }
            Menu();
        }

        /*for dsplay content of file function end*/

        
           /* write in a file function start*/

        public void WriteFile()
        {
            string filepath = @"C:\Users\DELL\Desktop\radixfile\";
            Console.Write("Enter FileName (use .txt extension) : ");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (File.Exists(Path))
            {
                Console.Write("Write your Content .... :");
                var content = Console.ReadLine();
                StreamWriter sw = new StreamWriter(Path);
                sw.Write(content);
                sw.Close();
                Console.WriteLine("Successfully Added Content");
                Menu();

            }

        }


        /* write in a function end*/


        /*for delete a file function start*/

        public void DeleteFile()
        {
            string filepath = @"C:\Users\DELL\Desktop\radixfile\";
            Console.Write("Enter FileName (use .txt extension) : ");
            string fileName = Console.ReadLine();
            string Path = filepath + fileName;
            if (File.Exists(Path))
            {
                File.Delete(Path);
                Console.WriteLine("File Successfully Deleted...!");
            }
            Menu();
        }

        /* for delete a file function end*/





        static void Main(string[] args)
        {
            Program program = new Program();
            program.Menu();
        }
    }

}

