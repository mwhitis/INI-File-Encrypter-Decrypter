from os import system
import configparser

DEFAULT_OUT_PATH = "C:\\Users\\Public\\Documents\\config.ini"
DEFAULT_DECRYPTED_PATH = "C:\\Users\\Public\\Documents\\Decrypted.ini"

try:
    flag = 1
    print("Enter Flag '-1 to Stop!")

    while (flag != "-1"):
        try:
            # system("title", "INI File Encrypter/Dycripter")
            print("Usage: ")
            print("Input 1 : Encrypting Ini File.")
            print("Input 2 : Decrypting Ini File:")
            i = int(input("Input = "))

            if (i == 1):
                #                                 // Read plain (decrypted) INI file.
                inputIni = configparser.ConfigParser()
                path = input("Enter Full Ini file location(Path): ")
                inputIni.read(path)

                passwd = input("Choose Password: ")
                #                                 options.EncryptionPassword = pass;
                outputIni = configparser.ConfigParser()
                for inputSec in inputIni.sections():
                    for sectionKey in inputIni[inputSec]:
                        outputIni[inputSec][sectionKey] = inputIni[inputSec][sectionKey]
                outputIni.write(DEFAULT_OUT_PATH)
                print(
                    f"Encrypted File is stored in Documents with name: config.ini and Password {passwd}")
            elif (i == 2):
                pass2 = input("Enter Encryption Password: ")
                file1 = configparser.ConfigParser()
                path2 = input("Enter Your Encrypted File With Path: ")
                file1.read_file(path2)

                file2 = configparser.ConfigParser()
                for sec1 in file1.sections():
                    for sectionKey in file1[sec1]:
                        file2[sec1][sectionKey] = file1[sec1][sectionKey]

                print("Decrypted File saved in Documents with Name Decrypted.ini.")
                print(
                    "Read or Make changes in it Save and Encrypt it again Pressing 1.")
                file2.write(DEFAULT_DECRYPTED_PATH)
        except Exception as ex:
            print(f"Error: {ex}")
            flag = input("Enter Flag:")
except Exception as ex:
    print(f"Error: {ex} ")
print("Exiting....")
