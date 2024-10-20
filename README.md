<p align="center">
    <a href="https://ra-studio.net" target="_blank">
        <img src="Images/RAStudio-logo.svg" alt="RA Studio Logo" width="200"/>
    </a>
</p>

# UI Toolkit Manipulators

## Description

UI Toolkit Manipulators is a Unity package that provides a collection of custom manipulators for Unity's UI Toolkit. These manipulators extend the functionality of UI Toolkit, allowing for more interactive and dynamic user interfaces.

## Features

- DraggableManipulator: Allows UI elements to be dragged
- ResizableManipulator: Enables resizing of UI elements
- ClickableManipulator: Handles click events on UI elements
- DoubleClickManipulator: Detects double-click events on UI elements
- HoverManipulator: Manages hover states for UI elements

## Installation

To install this package, follow these steps:

1. Open the Unity Package Manager (Window > Package Manager)
2. Click the '+' button and select "Add package from git URL..."
3. Enter the following URL: `https://github.com/RA-StudioX/UIToolkitManipulators.git`
4. Click 'Add'

## Usage

Here's a quick example of how to use the DraggableManipulator:

```csharp
using UnityEngine.UIElements;
using RAStudio.UIToolkit.Manipulators;

public class MyCustomElement : VisualElement
{
    public MyCustomElement()
    {
        this.AddManipulator(new DraggableManipulator());
    }
}
```

## Documentation

For more detailed information about the package, its components, and how to use them, please refer to the [full documentation](https://github.com/RA-StudioX/UIToolkitManipulators/blob/main/Documentation~/UIToolkitManipulators.md).

## Requirements

- Unity 2021.3 or later
- UIToolkit

## Contributing

Contributions are welcome! If you have any ideas, suggestions, or find bugs, feel free to open an issue or submit a pull request.

## License

This package is licensed under the MIT License. See the [LICENSE](https://github.com/RA-StudioX/UIToolkitManipulators/blob/main/LICENSE.md) file for details.

## Author

RA Studio

- Email: contact@ra-studio.net
- Website: https://ra-studio.net
- GitHub: https://github.com/RA-StudioX

## Support

If you encounter any issues or have questions, please file an issue on the [GitHub repository](https://github.com/RA-StudioX/UIToolkitManipulators/issues).
