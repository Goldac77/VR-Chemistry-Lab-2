# VR-Chemistry-Lab-2
 VR Chemisty Lab Version 2.0

# Unity 3D VR/XR Project Setup Guide

This repository contains a Unity 3D project modified to incorporate VR and XR interaction packages. Follow these steps to set up the project after cloning.

## Prerequisites

Make sure you have the following installed:

- [Unity 3D](https://unity.com/) (version 2022.3.0f1 or higher)
- [Git](https://git-scm.com/)

## Setup Instructions

1. **Clone the Repository**

    ```bash
    git clone https://github.com/Goldac77/VR-Chemistry-Lab-2.git
    ```

2. **Open the Project in Unity**

    - Launch Unity 3D.
    - Click on `Open` and navigate to the cloned directory.
    - Select the main Unity project folder and click `Open`.

3. **Installing Dependencies**

    - If any dependencies were listed in the `.gitignore`:
        - Check the "Dependencies" section below for acquiring missing assets or packages.

4. **Regenerate Ignored Folders**

    - Some folders and files might be excluded from the repository for optimization purposes. These might include:
        - `Library/`
        - `Temp/`
        - `Build/`
    - After opening the project, Unity will automatically generate these folders and files based on project settings and imported assets.

5. **Configurations and Settings**

    - If any project-specific settings need adjustment or configuration:
        - Check the relevant sections or scripts within the project and follow any provided instructions in their respective README files or documentation.

## Dependencies

- **Unity XR Interaction Toolkit**
    - If the `Packages/com.unity.xr.interaction.toolkit/` folder is ignored:
        - Obtain and import this package using Unity's Package Manager.
        - Open Unity, go to `Window -> Package Manager`.
        - Search for "XR Interaction Toolkit" and install it into the project.

- **External Assets**
    - If the project relies on assets not included in this repository:
        - Acquire and import these assets from the Unity Asset Store or other sources.
        - Follow any specific setup instructions provided by the asset creators.

## Additional Notes

- For any issues or troubleshooting, refer to the project's issue tracker or documentation.
- Feel free to reach out to the project maintainers for assistance or inquiries.

---
