# WebTeX
ASP .NET Server for Serving JIT Compiled LaTeX using ELDYN

# Description
WebTeX is a demo project to demonstrate how [ELDYN](https://github.com/jetspiking/ELDYN) can be used to JIT-compile dynamic LaTeX content and serve it to a user. To demonstrate this, the [NASA APOD API](https://api.nasa.gov/) is used to generate a LaTeX page according to the ELDYN templates.

<img src="https://raw.githubusercontent.com/jetspiking/WebTeX/main/Images/WebTeXHome.png" Width="400">

# Recommendations
This project directly returns the PDF as a response. This can cause problems in some browsers, where the content is not displayed inside the browser. In those cases the content is downloaded and only visible when the user opens the downloaded PDF. In addition, to support acting on form data (textfields, checkboxes, buttons inside the PDF), it is recommended to display the PDF inside a context window. An embed in HTML could allow hot-reloads and redirects after posts (to a new dynamically generated PDF via LaTeX), for example.

<img src="https://raw.githubusercontent.com/jetspiking/WebTeX/main/Images/WebTeXDemo.png" Width="400">

# Thank you for using WebTeX
If you enjoy this software series, you could consider supporting me by purchasing application [Colorpick - PRO](https://store.steampowered.com/app/1388790/Colorpick__PRO). For a few dollars (depending on Steam pricing in region) you receive a DRM-free Colorpick application.

<a href="https://www.buymeacoffee.com/DustinHendriks" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>
