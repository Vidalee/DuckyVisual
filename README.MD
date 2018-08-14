# DuckyVisual [![Build status](https://ci.appveyor.com/api/projects/status/duoflic3rusj83md?svg=true)](https://ci.appveyor.com/project/Vidalee/duckyvisual) [Download](https://github.com/Vidalee/DuckyVisual/releases)

(This application is still under development, everything is not finished yet. Feel free to open an issue or a PR)

DuckyVisual is an application that allows you to control the lighting color of each one of your keys. 
This application currently only supports the Shine 6 keyboard, but theorically every keyboard made by Ducky after the Shine 6 should be supported, however since I don't have these under my hand, they're not.
If you have one of these keyboards, reach me out at reachlink and I'll gladly make it supported !

What this application do is that it basically emulates the Ducky's software in order to switch the keyboard in "software" mode, and set it in a state where it's ready to receive key colors orders.

To change the color of the keys, a REST API server is launched on your computer, on the port 17742.

Just make POST calls to it with the help if the doc and you're done !

## API documentation

### `/colorKey`

Colors the desired key with the color you want. It takes 4 args:
* `key`: The key you want to light up
* `r`: Value of the red lightning
* `g`: Value of the green lightning
* `b`: Value of the blue lightning
 
Example : `http://localhost:17742/colorKey?key=G&r=0&g=0&b=255` will color the 'G' key in blue.

### `/colorAllKeyboard`

Colors all the keyboard with the desired color. It takes 3 args:
* `r`: Value of the red lightning
* `g`: Value of the green lightning
* `b`: Value of the blue lightning

Example : `http://localhost:17742/colorAllKeyboard?r=0&g=0&b=255` will color all your keyboard in blue.

### `/options`

Adjust the options to your needs.
* `autoUpdate`: Set it to false and the keyboard colors won't update automatically after using `/colorKey` or `/colorAllKeyboard`, you will need to use `/update`. Constructing the colors of the keys and then updating all of them may increase performance if you update the keyboard very frequently.

Example : `http://localhost:17742/options?autoUpdate=false` will disable the autoUpdate.

### `/update`

Manually update the colors of the keyboard

Example : `http://localhost:17742/update` will update the colors of the keyboard.