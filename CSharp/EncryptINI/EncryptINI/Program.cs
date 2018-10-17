using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadMilkman.Ini;

namespace EncryptINI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                int flag = 1;
                Console.WriteLine("Enter Flag '-1' to Stop!");
                while (flag != -1)
                {
                    try
                    {
                        Console.Title = "INI File Encrypter/Dycripter!";
                        Console.WriteLine("Usage: ");
                        Console.WriteLine("Input 1 : Encrypting Ini File.");
                        Console.WriteLine("Input 2  :Decrypting Ini File:");
                        Console.Write("Input = ");
                        int i = Convert.ToInt32(Console.ReadLine());

                        switch (i)
                        {
                            case 1:
                                // Read plain (decrypted) INI file.
                                IniFile inputIni = new IniFile();
                                Console.Write("Enter Full Ini file location(Path): ");
                                string path = Console.ReadLine();
                                inputIni.Load(@path);

                                // Write encrypted INI file.
                                IniOptions options = new IniOptions();
                                Console.Write("Choose Password: ");
                                string pass = Console.ReadLine();
                                options.EncryptionPassword = pass;

                                IniFile outputIni = new IniFile(options);
                                foreach (IniSection inputSec in inputIni.Sections)
                                    outputIni.Sections.Add(inputSec.Copy(outputIni));

                                outputIni.Save(@"C:\Users\Ankrita Rana\Documents\config.ini");
                                Console.WriteLine($"Encrypted File is stored in Documents with name: config.ini and Password {pass}");
                                break;
                            case 2:
                                // Read encrypted INI file.
                                IniOptions options2 = new IniOptions();
                                Console.Write("Enter Encryption Password: ");
                                string pass2 = Console.ReadLine();
                                options2.EncryptionPassword = pass2;

                                IniFile file1 = new IniFile(options2);
                                Console.Write("Enter Your Encrypted File With Path: ");
                                string path2 = Console.ReadLine();
                                file1.Load(@path2);


                                // Write plain (decrypted) INI file.
                                IniFile file2 = new IniFile();

                                foreach (IniSection sec1 in file1.Sections)
                                    file2.Sections.Add(sec1.Copy(file2));

                                Console.WriteLine("Decrypted File saved in Documents with Name Decrypted.ini.");
                                Console.WriteLine("Read or Make changes in it Save and Encrypt it again Pressing 1.");
                                file2.Save(@"C: \Users\Ankrita Rana\Documents\Decrypted.ini");
                                break;


                        }



                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    Console.Write("Enter Flag: ");
                    flag = Convert.ToInt32(Console.ReadLine());
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error "+ ex.Message);
            }
            Console.WriteLine("Exiting....");
        }
    }
}
