from pickle import TRUE
import requests
from requests.adapters import HTTPAdapter
from urllib3.util import Retry

import json
import matplotlib.pyplot as plt
import numpy as np
import threading

# This part is to make sure the HTTP GET method can retry if a timeout occurs.
session = requests.Session()
retry = Retry(connect=3, backoff_factor=0.5)
adapter = HTTPAdapter(max_retries=retry)
session.mount('http://', adapter)
session.mount('https://', adapter)

plt.ion()
fig=plt.figure()
ax = fig.add_subplot(111)

# These URLs are retrieved from NX-Wavestar's Web Server Window
# URLs for Channel 1 Waveform Data
CH1_Waveform_url = "http://127.0.0.1:22997/CH1"
CH1_Counter_url = "http://127.0.0.1:22997/CH1_Counter"

HTTP_GET_Data = session.get(CH1_Waveform_url) # Get the Channel Data
Waveform_Data = json.loads(HTTP_GET_Data.content) # Parse the JSON Data
Y_Axis = Waveform_Data["Waveform_Y_Data"] # The Y-Axis data is retrieved from the JSON Waveform data

# X-Axis data is not contained in the JSON Waveform data in order to speedup the process of getting Waveform Data
# X-Axis data is created using the Start Time, Stop Time and Data Points info contained in the JSON Waveform Data
# We can use Numpy's Linspace function to do this.
X_Axis = np.linspace(Waveform_Data["Start_Time"], Waveform_Data["Stop_Time"], num=Waveform_Data["Data_Points"])
line1, = ax.plot(X_Axis, Y_Axis, 'r-')

#NX-Wavestar: The counter is incremented when the waveform data is updated.
# The counter allows the users to know when the waveform data is updated.
# Getting the counter value is faster than getting the waveform data.
# There is no point in getting the same waveform data again and again. 
CH1_Counter = 0
while TRUE:
    Check_CH1_Counter = session.get(CH1_Waveform_url).content
    if (CH1_Counter != Check_CH1_Counter):
        CH1_Counter = Check_CH1_Counter
        HTTP_GET_Data = session.get(CH1_Waveform_url)
        Waveform_Data = json.loads(HTTP_GET_Data.content)
        Y_Axis = Waveform_Data["Waveform_Y_Data"]
        X_Axis = np.linspace(Waveform_Data["Start_Time"], Waveform_Data["Stop_Time"], num=Waveform_Data["Data_Points"])
        line1.set_data(X_Axis, Waveform_Data["Waveform_Y_Data"])
        fig.canvas.draw()
        fig.canvas.flush_events()