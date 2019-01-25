# MidiSilencer
Very niche program! So I was speedrunning classic Dink Smallwood (pre-HD releases), and an interesting aspect of it is how the game lags a little bit every time it accesses a new midi.

I kind of want to listen to my own music during this though, so at first I tried just deleting the midis. The game still ran properly, but now the lag was gone!

Because I'm an idiot we now have this program that takes the original midis and just lowers the volume on all notes as much as possible.

***1. Put in a folder with midis and run***

***2. A new folder will be created (midi_silent)***

***3. Now you have a folder of midis you can't listen to!***

## Credits

[NAudio](https://github.com/naudio/NAudio), great audio library which happens to have midi stuff too

[Costura.Fody](https://github.com/Fody/Costura), embedded the NAudio DLL and optimizes, everyone should use this always
