# UI Toolkit Manipulators Documentation

## Table of Contents

1. [Introduction](#introduction)
2. [Installation](#installation)
3. [Manipulators](#manipulators)
   - [DraggableManipulator](#draggablemanipulator)
   - [ResizableManipulator](#resizablemanipulator)
   - [ClickableManipulator](#clickablemanipulator)
   - [DoubleClickManipulator](#doubleclickmanipulator)
   - [HoverManipulator](#hovermanipulator)
4. [Usage Examples](#usage-examples)
5. [Troubleshooting](#troubleshooting)
6. [Contributing](#contributing)
7. [License](#license)
8. [Support](#support)

## Introduction

UI Toolkit Manipulators is a package that extends Unity's UI Toolkit by providing a set of custom manipulators. These manipulators allow for more interactive and dynamic user interfaces, enabling behaviors such as dragging, resizing, clicking, double-clicking, and hovering on UI elements.

## Installation

To install the UI Toolkit Manipulators package:

1. Open your Unity project.
2. Navigate to Window > Package Manager.
3. Click the '+' button and select "Add package from git URL..."
4. Enter the following URL: `https://github.com/RA-StudioX/UIToolkitManipulators.git`
5. Click 'Add' to install the package.

After installation, you can start using the manipulators in your UI Toolkit-based UI.

## Manipulators

### DraggableManipulator

The DraggableManipulator allows UI elements to be moved by clicking and dragging.

Usage:

```csharp
var element = new VisualElement();
element.AddManipulator(new DraggableManipulator());
```

### ResizableManipulator

The ResizableManipulator enables UI elements to be resized by clicking and dragging their edges or corners.

Usage:

```csharp
var element = new VisualElement();
element.AddManipulator(new ResizableManipulator());
```

### ClickableManipulator

The ClickableManipulator provides a way to handle click events on UI elements.

Usage:

```csharp
var element = new VisualElement();
element.AddManipulator(new ClickableManipulator(() => Debug.Log("Clicked!")));
```

### DoubleClickManipulator

The DoubleClickManipulator detects double-click events on UI elements. It allows you to specify the time threshold for considering two clicks as a double-click.

Usage:

```csharp
var element = new VisualElement();
// Using default time threshold (0.3 seconds)
element.AddManipulator(new DoubleClickManipulator(() => Debug.Log("Double clicked!")));

// Using custom time threshold (0.5 seconds)
element.AddManipulator(new DoubleClickManipulator(() => Debug.Log("Double clicked!"), 0.5f));
```

### HoverManipulator

The HoverManipulator manages hover states for UI elements, allowing you to respond to pointer enter and leave events.

Usage:

```csharp
var element = new VisualElement();
var hoverManipulator = new HoverManipulator();
hoverManipulator.OnHoverEnter += () => element.style.backgroundColor = Color.red;
hoverManipulator.OnHoverExit += () => element.style.backgroundColor = Color.white;
element.AddManipulator(hoverManipulator);
```

## Usage Examples

Here's an example of how to use multiple manipulators on a single element:

```csharp
public class CustomElement : VisualElement
{
    public CustomElement()
    {
        this.style.width = 100;
        this.style.height = 100;
        this.style.backgroundColor = Color.blue;

        this.AddManipulator(new DraggableManipulator());
        this.AddManipulator(new ResizableManipulator());

        var clickManipulator = new ClickableManipulator(() => Debug.Log("Clicked!"));
        this.AddManipulator(clickManipulator);

        var doubleClickManipulator = new DoubleClickManipulator(() => Debug.Log("Double clicked!"), 0.4f);
        this.AddManipulator(doubleClickMan);
    }
}
```

## Troubleshooting

- **Issue**: Manipulators not responding to input.
  **Solution**: Ensure that the manipulator is properly added to the VisualElement using the `AddManipulator()` method.

- **Issue**: Multiple manipulators interfering with each other.
  **Solution**: Be cautious when using multiple manipulators on the same element. Some combinations may lead to unexpected behavior.

- **Issue**: Hover and Drag manipulators on the same VisualElement work simultaneously.
  **Solution**: This is expected behavior. If you want to prevent dragging during hover, you'll need to implement custom logic to disable one manipulator while the other is active.

- **Issue**: Manipulators not working in runtime builds.
  **Solution**: Ensure that the manipulators are being added to the VisualElements at runtime, not just in editor scripts.

- **Issue**: DoubleClickManipulator not detecting double-clicks correctly.
  **Solution**: Adjust the `DoubleClickTimeThreshold` when creating the manipulator to better match your needs. For example: `new DoubleClickManipulator(OnDoubleClick, 0.5f)` for a longer threshold.

- **Issue**: ResizableManipulator not working on all edges of the VisualElement.
  **Solution**: Make sure the VisualElement has sufficient size and that its parent doesn't constrain its layout.

If you encounter any other issues or have questions about using these manipulators, please file an issue on our [GitHub repository](https://github.com/RA-StudioX/UIToolkitManipulators/issues). We're here to help!

## Contributing

We welcome contributions to the UI Toolkit Manipulators package! If you have ideas for new manipulators, improvements to existing ones, or bug fixes, please feel free to submit a pull request or open an issue on our GitHub repository.

## License

This package is licensed under the MIT License. See the [LICENSE](https://github.com/RA-StudioX/UIToolkitManipulators/blob/main/LICENSE.md) file for details.

## Support

For support, please use the following resources:

1. Check the documentation in this file for usage instructions and troubleshooting tips.
2. Visit our [GitHub Issues](https://github.com/RA-StudioX/UIToolkitManipulators/issues) page to see if your question has already been answered or to report a new issue.
3. For general questions about UI Toolkit, refer to the [Unity UI Toolkit documentation](https://docs.unity3d.com/Manual/UIElements.html).

Thank you for using UI Toolkit Manipulators!
