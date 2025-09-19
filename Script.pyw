from pathlib import Path
import tkinter as tk
import random
import keyboard
import threading
import time

OUTPUT_PATH = Path(__file__).parent
ASSETS_PATH = OUTPUT_PATH / Path(r"C:\Users\Duncan Jones\Downloads\Python Scripts\Auto Typer\build\assets\frame0")

def relative_to_assets(path: str) -> Path:
    return ASSETS_PATH / Path(path)

window = tk.Tk()
window.title("Auto Typer")
window.geometry("674x422")
window.configure(bg="#E3E3E3")

canvas = tk.Canvas(
    window,
    bg="#E3E3E3",
    height=422,
    width=674,
    bd=0,
    highlightthickness=0,
    relief="ridge"
)
canvas.place(x=0, y=0)

canvas.create_text(43.0, 53.0, anchor="nw", text="Start/Pause:  ", fill="#000000", font=("Inter", 12 * -1))
canvas.create_text(81.0, 91.0, anchor="nw", text="Stop:", fill="#000000", font=("Inter", 12 * -1))
canvas.create_text(81.0, 169.0, anchor="nw", text="Text:", fill="#000000", font=("Inter", 12 * -1))
canvas.create_text(74.0, 332.0, anchor="nw", text="Delay:", fill="#000000", font=("Inter", 12 * -1))
canvas.create_text(192.0, 332.0, anchor="nw", text="ms", fill="#000000", font=("Inter", 12 * -1))
canvas.create_text(321.0, 332.0, anchor="nw", text="ms", fill="#000000", font=("Inter", 12 * -1))
canvas.create_text(223.0, 330.0, anchor="nw", text="-", fill="#000000", font=("Inter", 12 * -1))

start_hotkey = "F1"
stop_hotkey = "F2"
hotkey_selecting = None

def update_hotkeys():
    keyboard.unhook_all()
    keyboard.add_hotkey(start_hotkey, toggle_typing)
    keyboard.add_hotkey(stop_hotkey, stop_typing)

def format_key(event):
    key = event.keysym.upper()
    special_keys = {
        "SHIFT_L": "Left Shift", "SHIFT_R": "Right Shift",
        "CONTROL_L": "Left Ctrl", "CONTROL_R": "Right Ctrl",
        "ALT_L": "Left Alt", "ALT_R": "Right Alt",
        "BACKSPACE": "Backspace", "RETURN": "Enter",
        "SPACE": "Space", "ESCAPE": "Escape",
        "TAB": "Tab", "WIN_L": "Windows", "GRAVE": "Grave", "CAPS_LOCK": "Caps Lock",
        "FN": "Fn"
    }
    if len(key) == 1 and not key.isalnum():
        return event.char if event.char else key
    return special_keys.get(key, key)

def on_key_press(event):
    global start_hotkey, stop_hotkey, hotkey_selecting
    if hotkey_selecting:
        new_key = format_key(event)
        if hotkey_selecting == "start":
            start_hotkey = new_key
            canvas.itemconfig(start_hotkey_label, text=new_key)
        elif hotkey_selecting == "stop":
            stop_hotkey = new_key
            canvas.itemconfig(stop_hotkey_label, text=new_key)
        hotkey_selecting = None
        update_hotkeys()

def set_hotkey(event, hotkey_type):
    global hotkey_selecting
    hotkey_selecting = hotkey_type
    if hotkey_type == "start":
        canvas.itemconfig(start_hotkey_label, text="Press Any Key")
    else:
        canvas.itemconfig(stop_hotkey_label, text="Press Any Key")

start_rectangle = canvas.create_rectangle(125.0, 50.0, 254.0, 72.0, fill="#FFFFFF", outline="#000000")
start_hotkey_label = canvas.create_text(189.0, 61.0, anchor="center", text=start_hotkey, fill="#000000", font=("Inter", 12 * -1))
canvas.tag_bind(start_rectangle, "<Button-1>", lambda event: set_hotkey(event, "start"))
canvas.tag_bind(start_hotkey_label, "<Button-1>", lambda event: set_hotkey(event, "start"))

stop_rectangle = canvas.create_rectangle(125.0, 88.0, 254.0, 110.0, fill="#FFFFFF", outline="#000000")
stop_hotkey_label = canvas.create_text(189.0, 99.0, anchor="center", text=stop_hotkey, fill="#000000", font=("Inter", 12 * -1))
canvas.tag_bind(stop_rectangle, "<Button-1>", lambda event: set_hotkey(event, "stop"))
canvas.tag_bind(stop_hotkey_label, "<Button-1>", lambda event: set_hotkey(event, "stop"))

text_input = tk.Text(window, font=("Inter", 12), bd=1, bg="#FFFFFF", fg="#000000", wrap="word", height=6, width=52, padx=2, pady=2, highlightthickness=1, highlightbackground="black")
text_input.place(x=125.0, y=164.0)
text_input.insert("1.0", "Insert Text Here")

min_delay = tk.StringVar(value="500")
max_delay = tk.StringVar(value="1000")

def validate_number_input(P):
    return P.isdigit() or P == ""

vcmd = window.register(validate_number_input)

min_delay_entry = tk.Entry(window, textvariable=min_delay, validate="key", validatecommand=(vcmd, "%P"), font=("Inter", 12), bd=1, bg="#FFFFFF", fg="#000000", highlightthickness=1, highlightbackground="black")
min_delay_entry.place(x=125.0, y=329.0, width=60.0, height=22.0)

max_delay_entry = tk.Entry(window, textvariable=max_delay, validate="key", validatecommand=(vcmd, "%P"), font=("Inter", 12), bd=1, bg="#FFFFFF", fg="#000000", highlightthickness=1, highlightbackground="black")
max_delay_entry.place(x=254.0, y=329.0, width=60.0, height=22.0)

pause_flag = threading.Event()
typing = False
paused = False

def auto_typing():
    global typing
    text = text_input.get("1.0", tk.END).strip()
    
    for char in text:
        if not typing:
            break
        pause_flag.wait()
        keyboard.write(char)
        time.sleep(random.uniform(int(min_delay.get()) / 1000, int(max_delay.get()) / 1000))
    
    typing = False

def toggle_typing():
    global typing, paused
    if typing:
        paused = not paused
        if paused:
            pause_flag.clear()
        else:
            pause_flag.set()
    else:
        typing = True
        pause_flag.set()
        threading.Thread(target=auto_typing, daemon=True).start()

def stop_typing():
    global typing
    typing = False
    pause_flag.set()

update_hotkeys()
window.bind_all("<Key>", on_key_press)
window.resizable(False, False)
window.mainloop()
