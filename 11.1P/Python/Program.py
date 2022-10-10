import os
from Clock import Clock

clock = Clock()

for x in range(86400):
    clock.Tick()
    print(clock.Time)
    os.system('cls')
