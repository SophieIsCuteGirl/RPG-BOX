using UnityEngine;
using System.IO;

public class saveObjects : MonoBehaviour
{
    // File path to save the data
    private string filePath;

    private void Awake()
    {
        // File path to save the data
        filePath = Path.Combine(Application.persistentDataPath, "gameData/Saves/objectData.sav");

        // Check if the folder "gameData/Saves" exists and create it if it doesn't
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }
    }

    public int nothing;
    private void Start()
    {
        // Save the object's position, rotation, and scale to the .sav file
        SavePosition(gameObject.name, transform);
        SaveRotation(gameObject.name, transform);
        SaveScale(gameObject.name, transform.localScale);
    }

    // Method to save the object's position to the .sav file
    public void SavePosition(string objectName, Transform objectTransform)
    {
        // Create the data string in the format "objectName,position,x,y,z"
        string data = objectName + ",position," + objectTransform.position.x + "," + objectTransform.position.y + "," + objectTransform.position.z + "\n";

        // Check if the file already exists
        if (File.Exists(filePath))
        {
            // Read all the lines of the file
            string[] lines = File.ReadAllLines(filePath);

            // Flag to check if the data already exists in the file
            bool found = false;

            // Loop through each line
            for (int i = 0; i < lines.Length; i++)
            {
                // Split the line into an array of strings using the "," character as the delimiter
                string[] lineData = lines[i].Split(',');

                // Check if the first element of the array is equal to the objectName and the second element is equal to "position"
                if (lineData[0] == objectName && lineData[1] == "position")
                {
                    found = true;
                    lines[i] = data;
                    break;
                }
            }

            // If the data was not found in the file, append the data to the file
            if (!found)
            {
                File.AppendAllText(filePath, data);
            }
            // If the data was found in the file, overwrite the file with the updated data
            else
            {
                File.WriteAllLines(filePath, lines);
            }
        }
        // If the file does not exist, create the file and write the data to it
        else
        {
            File.WriteAllText(filePath, data);
        }
    }

    // Method to save the object's rotation to the .sav file
    public void SaveRotation(string objectName, Transform objectTransform)
    {
        // Create the data string in the format "objectName,rotation,x,y,z,w"
        string data = objectName + ",rotation," + objectTransform.rotation.x + "," + objectTransform.rotation.y + "," + objectTransform.rotation.z + "," + objectTransform.rotation.w + "\n";

        // Check if the file already exists
        if (File.Exists(filePath))
        {
            // Read all the lines of the file
            string[] lines = File.ReadAllLines(filePath);

            // Flag to check if the data already exists in the file
            bool found = false;

            // Loop through each line
            for (int i = 0; i < lines.Length; i++)
            {
                // Split the line into an array of strings using the "," character as the delimiter
                string[] lineData = lines[i].Split(',');

                // Check if the first element of the array is equal to the objectName and the second element is equal to "rotation"
                if (lineData[0] == objectName && lineData[1] == "rotation")
                {
                    found = true;
                    lines[i] = data;
                    break;
                }
            }

            // If the data was not found in the file, append the data to the file
            if (!found)
            {
                File.AppendAllText(filePath, data);
            }
            // If the data was found in the file, overwrite the file with the updated data
            else
            {
                File.WriteAllLines(filePath, lines);
            }
        }
        // If the file does not exist, create the file and write the data to it
        else
        {
            File.WriteAllText(filePath, data);
        }
    }

    // Method to save the object's scale to the .sav file
    public void SaveScale(string objectName, Vector3 scale)
    {
        string data = objectName + "," + scale.x + "," + scale.y + "," + scale.z + "\n";
        File.AppendAllText(filePath, data);
    }

    // Method to load the object's position from the .sav file
    public Vector3 LoadPosition(string objectName)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] data = line.Split(',');
            if (data[0] == objectName && data[1] == "position")
            {
                return new Vector3(float.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]));
            }
        }

        // If the position data is not found, return Vector3.zero
        return Vector3.zero;
    }

    // Method to load the object's rotation from the .sav file
    public Quaternion LoadRotation(string objectName)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] data = line.Split(',');
            if (data[0] == objectName)
            {
                return new Quaternion(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]));
            }
        }

        return Quaternion.identity;
    }

    // Method to load the object's scale from the .sav file
    public Vector3 LoadScale(string objectName)
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] data = line.Split(',');
            if (data[0] == objectName)
            {
                return new Vector3(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]));
            }
        }

        return Vector3.one;
    }

    public void SaveInt(string objectName, string intName, int intValue)
    {
        // check if the data is already saved
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            bool found = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                if (data[0] == objectName && data[1] == intName)
                {
                    found = true;
                    data[2] = intValue.ToString();
                    lines[i] = string.Join(",", data);
                    break;
                }
            }
            if (!found)
            {
                string data = objectName + "," + intName + "," + intValue + "\n";
                File.AppendAllText(filePath, data);
            }
            else
            {
                File.WriteAllLines(filePath, lines);
            }
        }
        else
        {
            string data = objectName + "," + intName + "," + intValue + "\n";
            File.WriteAllText(filePath, data);
        }
    }
    public void SaveFloat(string objectName, string floatName, float floatValue)
    {
        // check if the data is already saved
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            bool found = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                if (data[0] == objectName && data[1] == floatName)
                {
                    found = true;
                    data[2] = floatValue.ToString();
                    lines[i] = string.Join(",", data);
                    break;
                }
            }
            if (!found)
            {
                string data = objectName + "," + floatName + "," + floatValue + "\n";
                File.AppendAllText(filePath, data);
            }
            else
            {
                File.WriteAllLines(filePath, lines);
            }
        }
        else
        {
            string data = objectName + "," + floatName + "," + floatValue + "\n";
            File.WriteAllText(filePath, data);
        }
    }

    public void SaveVector3(string objectName, string vector3Name, Vector3 vector3Value)
    {
        // Create the data string in the format "objectName,position,x,y,z"
        string data = objectName + "," + vector3Name + "," + vector3Value.x + "," + vector3Value.y + "," + vector3Value.z + "\n";

        // Check if the file already exists
        if (File.Exists(filePath))
        {
            // Read all the lines of the file
            string[] lines = File.ReadAllLines(filePath);

            // Flag to check if the data already exists in the file
            bool found = false;

            // Loop through each line
            for (int i = 0; i < lines.Length; i++)
            {
                // Split the line into an array of strings using the "," character as the delimiter
                string[] lineData = lines[i].Split(',');

                // Check if the first element of the array is equal to the objectName and the second element is equal to "position"
                if (lineData[0] == objectName && lineData[1] == vector3Name)
                {
                    found = true;
                    lines[i] = data;
                    break;
                }
            }

            // If the data was not found in the file, append the data to the file
            if (!found)
            {
                File.AppendAllText(filePath, data);
            }
            // If the data was found in the file, overwrite the file with the updated data
            else
            {
                File.WriteAllLines(filePath, lines);
            }
        }
        // If the file does not exist, create the file and write the data to it
        else
        {
            File.WriteAllText(filePath, data);
        }
    }

    public int LoadInt(string objectName, string intName)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] data = line.Split(',');
            if (data[0] == objectName && data[1] == intName)
            {
                return int.Parse(data[2]);
            }
        }

        return 0;
    }
    public float LoadFloat(string objectName, string floatName)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] data = line.Split(',');
            if (data[0] == objectName && data[1] == floatName)
            {
                return float.Parse(data[2]);
            }
        }

        return 0;
    }
    public Vector3 LoadVector3(string objectName, string vector3Name)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] data = line.Split(',');
            if (data[0] == objectName && data[1] == vector3Name)
            {
                return new Vector3(float.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]));
            }
        }

        return Vector3.zero;
    }

}