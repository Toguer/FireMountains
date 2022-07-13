using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public static class SaveManager
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private const string SAVE_EXTENSION = "txt";

    public static void Init()
    {
        //Para comprobar si existe el directorio donde voy a guardar mis datos
        //si no existe, lo creo
        if (!Directory.Exists(SAVE_FOLDER))
            Directory.CreateDirectory(SAVE_FOLDER);
    }

    //Esta es la función que se encarga de guardar los datos y que la vamos a llamar desde otro script
    public static void Save(string saveString)
    {
        //el while lo usamos para saber qué número de archivo estoy guardando (en el caso de que queramos tener
        //un histórico de guardado)
        int saveNumber = 1;
        while (File.Exists(SAVE_FOLDER + "save_" + saveNumber + "." + SAVE_EXTENSION))
            saveNumber++;

        //Guardamos los datos a través del saveString que le pasamos a la función que ya contiene la info
        //del json y los datos que queremos guardar
        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + "." + SAVE_EXTENSION, saveString);
    }

    public static string Load()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        //cogemos los archivos que hay en el directorio indicado con la extensión SAVE_EXTENSION
        //DA IGUAL EL NOMMBRE DEL ARCHIVO
        //Cogemos el archivo que ha sido escrito por última vez
        FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
        FileInfo mostRecentFile = null;
        foreach (FileInfo fileInfo in saveFiles)
        {
            if (mostRecentFile == null)
                mostRecentFile = fileInfo;
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                    mostRecentFile = fileInfo;
            }
        }
        //

        //Leer(cargar) los datos
        if (mostRecentFile != null)
        {
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            return saveString;
        }
        else
        {
            return null;
        }
    }

    public static int checkExistLoads()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
        return saveFiles.Length;
    }

    public static bool CheckGameSavedExists(int gameSlot)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*" + gameSlot + "." + SAVE_EXTENSION);
        return saveFiles.Any();
    }

    public static string especificLoad(int fileNumber)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        //cogemos los archivos que hay en el directorio indicado con la extensión SAVE_EXTENSION
        //DA IGUAL EL NOMMBRE DEL ARCHIVO
        //Cogemos el archivo que ha sido escrito por última vez
        FileInfo[] saveFiles = directoryInfo.GetFiles("save_" + fileNumber + "." + SAVE_EXTENSION);
        FileInfo mostRecentFile = null;
        foreach (FileInfo fileInfo in saveFiles)
        {
            if (mostRecentFile == null)
                mostRecentFile = fileInfo;
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                    mostRecentFile = fileInfo;
            }
        }


        //Leer(cargar) los datos
        if (mostRecentFile != null)
        {
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            return saveString;
        }
        else
        {
            return null;
        }
    }
    public static void Save(string saveString, int saveNumber)
    {
        Debug.Log("Intentamos guardar");
        //int saveNumber = 1;
        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + "." + SAVE_EXTENSION, saveString);
        /*if (File.Exists(SAVE_FOLDER + "save_" + saveNumber + "." + SAVE_EXTENSION))
        {
            
            //Guardamos los datos a través del saveString que le pasamos a la función que ya contiene la info
            //del json y los datos que queremos guardar
            
        }
        else
        {
            Debug.Log("File not exist");
        }
        */
    }

    public static void Delete(int gameSlot)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*" + gameSlot + "." + SAVE_EXTENSION + "*");
        foreach (FileInfo saveFile in saveFiles)
        {
            saveFile.Delete();
        }
    }

}