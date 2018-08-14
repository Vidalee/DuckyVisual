Here are the information I reverse engineered.

In `close.txt`, `open.txt` and `cm1.txt` you can find the raw data of the communications between my keyboard and my computer.

I created a small script, `extract_raw.py` to extract only the output reports (computer->keyboard) and present them in a manner that the program will understand. Extracted files have the `_extract`  suffix.