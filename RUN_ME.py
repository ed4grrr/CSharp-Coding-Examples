import os
import subprocess

def run_exe_on_docx_files(exe_path, directory):
    # Check if the directory exists
    if not os.path.isdir(directory):
        print(f"Error: The directory '{directory}' does not exist.")
        return


       # Walk through all files in the directory
    for root, dirs, files in os.walk(directory):
        for filename in files:
            # Check if the file ends with a .docx extension
            if filename.endswith(".docx"):
                # Get the full path of the .docx file
                file_path = os.path.join(root, filename)
                
                # Print the file being processed
                print(f"Processing file: {file_path}")
                
                # Run the executable with the .docx file as an argument
                try:
                    subprocess.run([exe_path, file_path], check=True)
                    print(f"Successfully processed {file_path}")
                except subprocess.CalledProcessError as e:
                    print(f"Error processing {file_path}: {e}")

def main():
    # Ask the user for the directory containing the .docx files
    directory = input("Enter the path to the directory containing the .docx files: ")

    # Path to the .exe file
    exe_path = r"C:\Users\Edgar W Bowlin III\source\repos\C# Coding Examples\ChatGPTPowerPointPromptCreator\bin\Debug\ChatGPTPowerPointPromptCreator.exe"

    # Run the executable over the .docx files in the directory
    run_exe_on_docx_files(exe_path, directory)

if __name__ == "__main__":
    main()