# NX-StarWave (Incomplete, in progress...) ( Oscilloscope Software)
NX-StarWave is an Oscilloscope software for Tektronix TDS 500 600 700 series.
It supports both open source and commercial GPIB adapters.
This software utilizes multithreading to download waveforms and render them as fast as possible.
This software is only runs on Microsoft Windows (7, 8, 10 and onwards). Windows 7 users must ensure that .Net Framework 4.7.2 or higher is installed. A Visa software (NI Visa, Keysight IO Suite, R&S VISA) may also be required.

## Main NX-StarWave Window
This is the main window where users can control how waveforms are captured, open various waveform display windows among other things.
![Main NX-StarWave Window](https://github.com/Niravk1997/NX-StarWave/blob/main/Screenshots/NX-StarWave_Window.gif)

## YT Window
This window displays time domain waveforms.
![YT Window](https://github.com/Niravk1997/NX-StarWave/blob/main/Screenshots/CH1_YT_Window.gif)

## FFT Windows
FFTs are computed from YT waveforms. There is no FFT size limit. The length of the FFT depends on time domain waveform length. FFTs are computed using the entire YT waveform, no zero padding or waveform cropping required.
![FFT Window](https://github.com/Niravk1997/NX-StarWave/blob/main/Screenshots/CH1_FFT_Window.gif)
![FFT Waterfall Window](https://github.com/Niravk1997/NX-StarWave/blob/main/Screenshots/CH1_FFT_Waterfall_Window.gif)
![FFT ColorGraded Window](https://github.com/Niravk1997/NX-StarWave/blob/main/Screenshots/CH1_FFT_ColorGraded_Window.gif)
## Math Windows
Showcases some of the software's features.
![Waveform Calculator](https://github.com/Niravk1997/NX-StarWave/blob/main/Screenshots/Waveform_Calculator_Window.gif)
![NodeEditor](https://github.com/Niravk1997/NX-StarWave/blob/main/Screenshots/NodeEditor_Math_Window.gif)
## Waveform Player
Store, load and playback waveforms. Save/load waveforms into SQLite database. 
![Waveform Player](https://github.com/Niravk1997/NX-StarWave/blob/main/Screenshots/Waveform_Player.PNG)