import os
import time
import pyautogui
from config import config
    
def alt_tab():    
    pyautogui.keyDown('alt')
    pyautogui.press(['tab'])
    pyautogui.keyUp('alt')

def type_text_from_file(file_name, delay):
    try:
        project_path = os.getcwd()
        file_path = os.path.join(project_path + '/source/', file_name)

        with open(file_path, 'r') as file:
            lines = file.readlines()
            for line in lines:
                line = line.strip()
                for char in line:
                    pyautogui.typewrite(char)
                    time.sleep(delay)

                pyautogui.press('enter')

    except FileNotFoundError:
        print(f"File not found: {file_path}")
    except Exception as e:
        print(f"An error occurred: {e}")

alt_tab()
time.sleep(10)
type_text_from_file(config['file_name'], config['delay'])