import os
with open('cm1_extract.txt', 'a+') as extract:
    with open('cm1.txt') as f:
        lines = f.readlines()
        i = -1
        for line in lines:
            if i > 0:
                i = i - 1
                extract.write(line.rstrip()[10:58])
            if i == 0:
                i = i - 1
                extract.write('\n')
            if 'Output Report' in line:
                i = 4

